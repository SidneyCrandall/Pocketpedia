using Microsoft.Extensions.Configuration;
using Pocketpedia.Models;
using Pocketpedia.Utils;
using System;
using System.Collections.Generic;
using System.IO;
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

        private static readonly HttpClient client = new HttpClient();

        public async Task<List<BugFromApi>> BugsFromApi()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetStreamAsync($"http://acnhapi.com/v1/bugs");
            var apiBugs = await JsonSerializer.DeserializeAsync<Dictionary<string, ApiBug>>(response);
            //    if (apiBugs == null)
            //    {
            //        return null;
            //    }
            //    //Console.WriteLine(apiBugs.ContainsKey("{Pocketpedia.Models.ApiBug}"));

            var locationRepo = new LocationRepository();

            var desiredResponse = apiBugs.Values.Select(apiBug => new Bug()
            {
                AcnhApiId = apiBug.id,
                Name = apiBug.filename,
                LocationId = apiBug.availability.location,
                ImageUrl = apiBug.image_uri,
            });

            return null;
        }

        public List<Bug> GetAllBugs()
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
                                        VALUES (@Name, @ImageUrl, @LocationId, @UserProfileId, 1)";

                    DbUtils.AddParameter(cmd, "@AcnhApiId", bug.AcnhApiId);
                    DbUtils.AddParameter(cmd, "@Name", bug.Name);
                    DbUtils.AddParameter(cmd, "@ImageUrl", bug.ImageUrl);
                    DbUtils.AddParameter(cmd, "@LocationId", bug.LocationId);
                    DbUtils.AddParameter(cmd, "@UserProfileId", bug.UserProfileId);

                    bug.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
