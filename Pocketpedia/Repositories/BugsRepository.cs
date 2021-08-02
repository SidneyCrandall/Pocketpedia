using Microsoft.Extensions.Configuration;
using Pocketpedia.Models;
using Pocketpedia.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using System.IO;

namespace Pocketpedia.Repositories
{
    public class BugsRepository : BaseRepository, IBugsRepository
    {
        public BugsRepository(IConfiguration configuration, ILocationRepository locationRepository) : base(configuration)
        {
            this.locationRepository = locationRepository;
        }

        private static readonly HttpClient client = new HttpClient();
        private readonly ILocationRepository locationRepository;

        public async Task<List<Bug>> BugsFromApi()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetStreamAsync($"http://acnhapi.com/v1/bugs");
            var apiBugs = await JsonSerializer.DeserializeAsync<Dictionary<string, ApiBug>>(response);

            var locations = locationRepository.GetLocations();
            

            var desiredResponse = apiBugs.Values.Select(apiBug => new Bug()
            {
                AcnhApiId = apiBug.id,
                Name = apiBug.name.nameUSen,
                LocationId = locations.FirstOrDefault(location => apiBug.availability.location == location.Name).Id,
                LocationName = apiBug.availability.location,
                ImageUrl = apiBug.icon_uri

            }).ToList();

            return desiredResponse;
        }

        public List<Bug> GetAllBugs()
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT b.Id as BugId, b.AcnhApiId, b.Name, b.LocationId, l.Name AS LocationName, b.ImageUrl, b.UserProfileId, b.Caught
                                        FROM Bugs b
                                        LEFT JOIN Location l ON b.LocationId = l.id";

                    var reader = cmd.ExecuteReader();

                    var bugs = new List<Bug>();

                    while (reader.Read())
                    {
                        bugs.Add(new Bug()
                        {
                            Id = DbUtils.GetInt(reader, "BugId"),
                            AcnhApiId = DbUtils.GetInt(reader, "AcnhApiId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                            LocationId = DbUtils.GetInt(reader, "LocationId"),
                            Location = new Location()
                            {
                                Id = DbUtils.GetInt(reader, "LocationId"),
                                Name = DbUtils.GetString(reader, "LocationName")
                            },
                          
                            UserProfileId = DbUtils.GetInt(reader, "UserProfileId")
                        });
                    }

                    reader.Close();

                    return bugs;
                }
            }
        }

        public List<Bug> GetBugsByUserId(string firebaseUserId)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT b.Id as BugId, b.AcnhApiId, b.Name, b.LocationId, b.ImageUrl, b.UserProfileId, b.Caught
                                        FROM Bugs b";

                    var reader = cmd.ExecuteReader();

                    var bugs = new List<Bug>();

                    while (reader.Read())
                    {
                        bugs.Add(new Bug()
                        {
                            Id = DbUtils.GetInt(reader, "BugId"),
                            AcnhApiId = DbUtils.GetInt(reader, "AcnhApiId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                            LocationId = DbUtils.GetInt(reader, "LocationId"),
                            UserProfileId = DbUtils.GetInt(reader, "UserProfileId")
                        });
                    }

                    reader.Close();

                    return bugs;
                }
            }
        }

        public void Add(Bug bug)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Bugs (AcnhApiId, Name, ImageUrl, LocationId, UserProfileId, Caught)
                                        OUTPUT INSERTED.ID
                                        VALUES (@AcnhApiId, @Name, @ImageUrl, @LocationId, @UserProfileId, @Caught)";

                    DbUtils.AddParameter(cmd, "@AcnhApiId", bug.AcnhApiId);
                    DbUtils.AddParameter(cmd, "@Name", bug.Name);
                    DbUtils.AddParameter(cmd, "@ImageUrl", bug.ImageUrl);
                    DbUtils.AddParameter(cmd, "@LocationId", bug.LocationId);
                    DbUtils.AddParameter(cmd, "@UserProfileId", bug.UserProfileId);
                    DbUtils.AddParameter(cmd, "@Caught", bug.Caught);

                    bug.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
