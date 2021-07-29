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

        public async Task<List<SeaCreatureFromApi>> SeaCreaturesFromAPi()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetStreamAsync($"http://acnhapi.com/v1/sea");
            var apiSeaCreatures = await JsonSerializer.DeserializeAsync<Dictionary<string, ApiSeaCreature>>(response);
            var desiredResponse = apiSeaCreatures.Values.Select(apiSeaCreature => new SeaCreature()
            {
                AcnhApiId = apiSeaCreature.id,
                Name = apiSeaCreature.filename,
                ImageUrl = apiSeaCreature.image_uri,
            });
        }

        public void Add(SeaCreature seaCreatures)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Fossils (Name, AcnhApiId, ImageUrl, UserProfileId, Caught)
                                        OUTPUT INSERTED.ID
                                        VALUES (@Name, @AcnhApiId, @ImageUrl, @UserProfileId, @Caught)";

                    DbUtils.AddParameter(cmd, "@Name", seaCreatures.Name);
                    DbUtils.AddParameter(cmd, "@AcnhApiId", seaCreatures.AcnhApiId);
                    DbUtils.AddParameter(cmd, "@ImageUrl", seaCreatures.ImageUrl);
                    DbUtils.AddParameter(cmd, "@UserProfileId", seaCreatures.UserProfileId);
                    DbUtils.AddParameter(cmd, "@Caught", seaCreatures.Caught);

                    seaCreatures.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}