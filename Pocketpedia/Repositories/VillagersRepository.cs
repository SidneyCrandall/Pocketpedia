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
                ImageUrl = apiVillager.icon_uri,

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
                                               v.ImageUrl, v.Birthday, v.UserProfileId
                                        FROM Villager v
                                        ORDER BY v.Birthday DESC";

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

        public List<Villager> GetVillagersByUser(string FirebaseUserId)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT v.Id, v.AcnhApiId, v.Name, v.ImageUrl,
                                               v.Birthday, v.UserProfileId,
                                               up.DisplayName, up.Email
                                        FROM Villagers v
                                              LEFT JOIN UserProfile up ON v.UserProfileId = up.Id
                                        WHERE up.FirebaseUserId = @FirebaseUserId
                                        ORDER BY v.Birthday Desc";

                    DbUtils.AddParameter(cmd, "@FirebaseUserId", FirebaseUserId);

                    var reader = cmd.ExecuteReader();

                    var villagers = new List<Villager>();

                    while (reader.Read())
                    {
                        villagers.Add(new Villager()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
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
                    cmd.CommandText = @"INSERT INTO Villagers (AcnhApiId, Name, ImageUrl, Birthday, UserProfileId, IsResiding)
                                    OUTPUT INSERTED.ID 
                                    VALUES (@AcnhApiId, @Name, @ImageUrl, @Birthday, @UserProfileId, @IsResiding)";

                    DbUtils.AddParameter(cmd, "@AcnhApiId", villager.AcnhApiId);
                    DbUtils.AddParameter(cmd,"@Name", villager.Name);
                    DbUtils.AddParameter(cmd, "@ImageUrl", villager.ImageUrl);
                    DbUtils.AddParameter(cmd, "@Birthday", villager.Birthday);
                    DbUtils.AddParameter(cmd, "@UserProfileId", villager.UserProfileId);
                    DbUtils.AddParameter(cmd, "@IsResiding", villager.IsResiding);

                    villager.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}