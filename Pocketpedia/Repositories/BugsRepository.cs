using Microsoft.Extensions.Configuration;
using Pocketpedia.Models;
using Pocketpedia.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public class BugsRepository : BaseRepository, IBugsRepository
    {
        public BugsRepository(IConfiguration configuration) : base(configuration) { }

        // Using HttpClient to call an external API. This will be used to get all the items 
        private static readonly HttpClient client = new HttpClient();

        private static async Task<List<BugList>> BugsFromApi(object bug)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var bugTask = client.GetStreamAsync($"http://acnhapi.com/v1/bugs");
            var response = await JsonSerializer.DeserializeAsync<ApiResponse>(await bugTask);
            if (response.items == null)
            {
                return null;
            }

            var desiredResponse = response.items.Select(item => new BugList(item.id, item.name, item.availability.location, item.availability.northernMonths, item.imageUrl)).ToList();

            return desiredResponse;
        }

        public List<Bugs> GetAllBugs()
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT b.Id as BugId, b.AcnhApiId, b.Name, b.LocationId, b.SeasonAvailabilityId , b.ImageUrl, b.UserProfileId
                                        FROM Bugs b";

                    var reader = cmd.ExecuteReader();

                    var bugs = new List<Bugs>();

                    while (reader.Read())
                    {
                        bugs.Add(new Bugs()
                        {
                            Id = DbUtils.GetInt(reader, "BugId"),
                            AcnhApiId = DbUtils.GetInt(reader, "AcnhApiId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            LocationId = DbUtils.GetInt(reader, "LocationId"),
                            SeasonAvailabilityId = DbUtils.GetInt(reader, "SeasonAvailabilityId "),
                            ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                            UserProfileId = DbUtils.GetInt(reader, "UserProfileId")
                        });
                    }

                    reader.Close();

                    return bugs;
                }
            }
        }

        public void Add(Bugs bug)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Bugs (AcnhApiId, Name, ImageUrl, LocationId, SeasonAvailabilityId, UserProfileId, Caught)
                                        OUTPUT INSERTED.ID
                                        VALUES (@Name, @ImageUrl, @LocationId, @SeasonAvailabilityId, @UserProfileId, 1)";

                    DbUtils.AddParameter(cmd, "@AcnhApiId", bug.AcnhApiId);
                    DbUtils.AddParameter(cmd, "@Name", bug.Name);
                    DbUtils.AddParameter(cmd, "@ImageUrl", bug.ImageUrl);
                    DbUtils.AddParameter(cmd, "@LocationId", bug.LocationId);
                    DbUtils.AddParameter(cmd, "@SeasonAvailabilityId", bug.SeasonAvailabilityId);
                    DbUtils.AddParameter(cmd, "@UserProfileId", bug.UserProfileId);

                    bug.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
