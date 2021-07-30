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
    public class VillagersRepository : BaseRepository, IVillagersRepository
    {
        public VillagersRepository(IConfiguration configuration) : base(configuration) { }


        private static readonly HttpClient client = new HttpClient();

        public async Task<List<Villager>> VillagersFromApi()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetStreamAsync($"http://acnhapi.com/v1/villagers");
            var apiVillagers = await JsonSerializer.DeserializeAsync<Dictionary<string, ApiVillager>>(response);
            var desiredResponse = apiVillagers.Values.Select(apiVillager => new Villager()
            {
                AcnhApiId = apiVillager.id,
                Name = apiVillager.name.nameUSen,
                Birthday = apiVillager.birthdaystring,
                ImageUrl = apiVillager.image_uri,
            }).ToList();

            return desiredResponse;
        }

        public List<Villager> GetVillagers()
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT v.Id as VillagerId, v.AcnhApiId, v.Name, 
                                               v.ImagUrl, v.Birthday, v.UserPRofileId
                                        FROM Villager v";

                    var reader = cmd.ExecuteReader();

                    var villagers = new List<Villager>();

                    while (reader.Read())
                    {
                        villagers.Add(new Villager()
                        {
                            Id = DbUtils.GetInt(reader, "VillagerId"),
                            AcnhApiId = DbUtils.GetInt(reader, "AcnhApiId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                            Birthday = DbUtils.GetString(reader, "Birthday"),
                            UserProfileId = DbUtils.GetInt(reader, "UserProfileId")
                        });
                    }

                    reader.Close();

                    return villagers;
                }
            }
        }

        public void Add(Villager villager)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Villagers (AcnhApiId, Name, ImageUrl, Birthday, UserProfileId)
                                    OUTPUT INSERTED.ID 
                                    VALUES (@AcnhApiId, @Name, ImageUrl @Birthday, @UserProfileId)";

                    cmd.Parameters.AddWithValue("@AcnhApiId", villager.AcnhApiId);
                    cmd.Parameters.AddWithValue("@Name", villager.Name);
                    cmd.Parameters.AddWithValue("@ImageUrl", villager.ImageUrl);
                    cmd.Parameters.AddWithValue("@Birthday", villager.Birthday);
                    cmd.Parameters.AddWithValue("@UserProfileId", villager.UserProfileId);

                    villager.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}