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
    public class SeaCreaturesRepository : BaseRepository, ISeaCreaturesRepository
    {
        public SeaCreaturesRepository(IConfiguration configuration) : base(configuration) { }

        private static readonly HttpClient client = new HttpClient();

        public async Task<List<SeaCreature>> SeaCreaturesFromApi()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetStreamAsync($"http://acnhapi.com/v1/sea");
            var apiSeaCreatures = await JsonSerializer.DeserializeAsync<Dictionary<string, ApiSeaCreature>>(response);

            var desiredResponse = apiSeaCreatures.Values.Select(apiSeaCreature => new SeaCreature()
            {

                AcnhApiId = apiSeaCreature.id,
                Name = apiSeaCreature.name.nameUSen,
                ImageUrl = apiSeaCreature.icon_uri,

            }).ToList();

            return desiredResponse;
        }

        public List<SeaCreature> GetSeaCreatures()
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT s.Id, s.AcnhApiId, s.Name, s.ImageUrl, s.UserProfileId, s.Caught
                                        
                                        FROM SeaCreatures s";

                    var reader = cmd.ExecuteReader();

                    var seaCreatures = new List<SeaCreature>();

                    while (reader.Read())
                    {
                        seaCreatures.Add(new SeaCreature()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            AcnhApiId = DbUtils.GetInt(reader, "AcnhApiId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                            UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                            Caught = DbUtils.IsDbNull(reader, "Caught")
                        });
                    }

                    reader.Close();

                    return seaCreatures;
                }
            }
        }

        public List<SeaCreature> GetSeaCreatureByUserId(string firebaseUserId)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT s.Id, s.AcnhApiId, s.Name, s.ImageUrl, s.UserProfileId, s.Caught,
                                               up.DisplayName, up.Email
                                        FROM SeaCreatures s
                                             LEFT JOIN UserProfile up ON s.UserProfileId = up.Id
                                        WHERE up.FirebaseUserId = @FirebaseUserId";

                    DbUtils.AddParameter(cmd, "@FirebaseUserId", firebaseUserId);

                    var reader = cmd.ExecuteReader();

                    var seaCreatures = new List<SeaCreature>();

                    while (reader.Read())
                    {
                        seaCreatures.Add(new SeaCreature()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            AcnhApiId = DbUtils.GetInt(reader, "AcnhApiId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                            Caught = DbUtils.IsDbNull(reader, "Caught"),
                            UserProfileId = DbUtils.GetInt(reader, "UserProfileId")
                        });
                    }

                    reader.Close();

                    return seaCreatures;
                }
            }
        }

        public void Add(SeaCreature seaCreature)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO SeaCreatures (AcnhApiId, Name, ImageUrl, UserProfileId, Caught)
                                        OUTPUT INSERTED.ID
                                        VALUES (@AcnhApiId, @Name, @ImageUrl, @UserProfileId, @Caught)";

                    DbUtils.AddParameter(cmd, "@AcnhApiId", seaCreature.AcnhApiId);
                    DbUtils.AddParameter(cmd, "@Name", seaCreature.Name);
                    DbUtils.AddParameter(cmd, "@ImageUrl", seaCreature.ImageUrl);
                    DbUtils.AddParameter(cmd, "@UserProfileId", seaCreature.UserProfileId);
                    DbUtils.AddParameter(cmd, "@Caught", seaCreature.Caught);

                    seaCreature.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}