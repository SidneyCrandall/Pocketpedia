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
    public class FossilsRepository : BaseRepository, IFossilsRepository
    {
        public FossilsRepository(IConfiguration configuration) : base(configuration) { }


        private static readonly HttpClient client = new HttpClient();

        public async Task<List<Fossil>> FossilsFromApi()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetStreamAsync($"http://acnhapi.com/v1/fossils");
            var apiFossils = await JsonSerializer.DeserializeAsync<Dictionary<string, ApiFossil>>(response);
            var desiredResponse = apiFossils.Values.Select(apiFossil => new Fossil()
            {
                Name = apiFossil.filename,
                ImageUrl = apiFossil.image_uri

            }).ToList();

            return desiredResponse;
        }

        public List<Fossil> GetFossils()
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT fo.Id, fo.Name, fo.ImageUrl, fo.UserProfileId, fo.Discovered
                                        FROM Fossils fo";

                    var reader = cmd.ExecuteReader();

                    var fossils = new List<Fossil>();

                    while (reader.Read())
                    {
                        fossils.Add(new Fossil()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                            UserProfileId = DbUtils.GetInt(reader, "UserProfileId")
                           
                        });
                    }

                    reader.Close();

                    return fossils;
                }
            }
        }

        public void Add(Fossil fossils)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Fossils (Name, ImageUrl, UserProfileId, Discovered)
                                        OUTPUT INSERTED.ID
                                        VALUES (@Name, @ImageUrl, @UserProfileId, @Discovered)";

                    DbUtils.AddParameter(cmd, "@Name", fossils.Name);
                    DbUtils.AddParameter(cmd, "@ImageUrl", fossils.ImageUrl);
                    DbUtils.AddParameter(cmd, "@UserProfileId", fossils.UserProfileId);
                    DbUtils.AddParameter(cmd, "@Discovered", fossils.Discovered);

                    fossils.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
