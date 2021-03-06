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
    public class ArtRepository : BaseRepository, IArtRepository
    {
        public ArtRepository(IConfiguration configuration) : base(configuration) { }


        //HttpClient is used to send an HTTP request, using a URL.HttpClient can be used to make Web API requests.
        private static readonly HttpClient client = new HttpClient();

        public async Task<List<Art>> ArtsFromApi()
        {
            // Afterwards, we have set the base URL for the HTTP request and set the Accept header.
            // Set Accept header to "application/json" that tells the Server to send the data into JSON format.
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // Send a GET request
            // If the response contains success code as response, it means the response body contains the data in the form of JSON.
            // ReadAsAsync method is used to deserialize the JSON object.
            var response = await client.GetStreamAsync($"http://acnhapi.com/v1/art");
            var apiArts = await JsonSerializer.DeserializeAsync<Dictionary<string, ApiArt>>(response);

            var desiredResponse = apiArts.Values.Select(apiArt => new Art()
            {
                AcnhApiId = apiArt.id,
                Name = apiArt.name.nameUSen,
                ImageUrl = apiArt.image_uri,
                HasFake = apiArt.hasFake

            }).ToList();

            return desiredResponse;
        }


        public List<Art> GetArtByUser(string firebaseUserId)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT a.Id, a.AcnhApiId, a.Name, a.ImageUrl, 
                                              a.UserProfileId, up.DisplayName, up.Email
                                       FROM Art a
                                            LEFT JOIN UserProfile up ON a.UserProfileId = up.Id
                                       WHERE up.FirebaseUserId = @FirebaseUserId";

                    DbUtils.AddParameter(cmd, "@FirebaseUserId", firebaseUserId);

                    var reader = cmd.ExecuteReader();

                    var arts = new List<Art>();

                    while (reader.Read())
                    {
                        arts.Add(new Art()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            AcnhApiId = DbUtils.GetInt(reader, "AcnhApiId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                            UserProfileId = DbUtils.GetInt(reader, "UserProfileId")
                        });
                    }

                    reader.Close();

                    return arts;
                }
            }
        }

        public void Add(Art art)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Art ( AcnhApiId, [Name], ImageUrl, UserProfileId, HasFake, Obtained)
                                        OUTPUT INSERTED.ID
                                        VALUES (@AcnhApiId, @Name, @ImageUrl, @UserProfileId, @HasFake, @Obtained)";

                    DbUtils.AddParameter(cmd, "@AcnhApiId", art.AcnhApiId);
                    DbUtils.AddParameter(cmd, "@Name", art.Name);
                    DbUtils.AddParameter(cmd, "@ImageUrl", art.ImageUrl);
                    DbUtils.AddParameter(cmd, "@UserProfileId", art.UserProfileId);
                    DbUtils.AddParameter(cmd, "@HasFake", art.HasFake);
                    DbUtils.AddParameter(cmd, "@Obtained", art.Obtained);


                    art.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}