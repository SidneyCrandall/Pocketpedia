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
    public class FishRepository : BaseRepository, IFishRepository
    {
        public FishRepository(IConfiguration configuration) : base(configuration) { }

        //private static readonly HttpClient client = new HttpClient();

        //public async Task<List<Fish>> FishesFromAPi()
        //{
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/json"));

        //    var response = await client.GetStreamAsync($"http://acnhapi.com/v1/fossils");
        //    var apiFishes = await JsonSerializer.DeserializeAsync<Dictionary<string, ApiFish>>(response);

        //    var desiredResponse = apiFishes.Values.Select(apiFish => new Fish()
        //    {
        //        AcnhApiId = apiFish.id,
        //        Name = apiFish.filename,
        //        LocationId = locations.FirstOrDefault(location => apiBug.availability.location == location.Name).Id,
        //        ImageUrl = apiFish.image_uri
        //    });
        //}

        public List<Fish> GetAllFish()
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT f.Id as FishId, f.AcnhApiId, f.Name, f.ImageUrl, f.LocationId, f.UserProfileId
                                        FROM Fish f";

                    var reader = cmd.ExecuteReader();

                    var fishes = new List<Fish>();

                    while (reader.Read())
                    {
                        fishes.Add(new Fish()
                        {
                            Id = DbUtils.GetInt(reader, "FishId"),
                            AcnhApiId = DbUtils.GetInt(reader, "AcnhApiId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            LocationId = DbUtils.GetInt(reader, "LocationId"),
                            UserProfileId = DbUtils.GetInt(reader, "UserProfileId")
                        });
                    }

                    reader.Close();
                    return fishes;
                }
            }
        }

        public void Add(Fish fish)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Fish (Name, AcnhApiId, ImageUrl, LocationId, UserProfileId, Caught)
                                        OUTPUT INSERTED.ID
                                        VALUES (@Name, @AcnhApiId, @ImageUrl, @LocationId, @UserProfileId, @Caught)";

                    DbUtils.AddParameter(cmd, "@Name", fish.Name);
                    DbUtils.AddParameter(cmd, "@AcnhApiId", fish.AcnhApiId);
                    DbUtils.AddParameter(cmd, "@ImageUrl", fish.ImageUrl);
                    DbUtils.AddParameter(cmd, "@LocationId", fish.LocationId);
                    DbUtils.AddParameter(cmd, "@UserProfileId", fish.UserProfileId);
                    DbUtils.AddParameter(cmd, "@Caught", fish.Caught);
                }
            }
        }
    }
}
