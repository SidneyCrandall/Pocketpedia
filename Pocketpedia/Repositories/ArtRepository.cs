﻿using Microsoft.Extensions.Configuration;
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

        private static readonly HttpClient client = new HttpClient();

        public async Task<List<Art>> ArtsFromApi()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetStreamAsync($"http://acnhapi.com/v1/art");
            var apiArts = await JsonSerializer.DeserializeAsync<Dictionary<string, ApiArt>>(response);

            var desiredResponse = apiArts.Values.Select(apiArt => new Art()
            {
                AcnhApiId = apiArt.id,
                Name = apiArt.filename,
                ImageUrl = apiArt.image_uri,
                HasFake = apiArt.hasFake
            }).ToList();

            return desiredResponse;
        }

        public List<Art> GetAllArt()
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT a.Id as ArtId, a.AcnhApiId, a.Name, a.ImageUrl, a.hasFake, a.UserProfileId
                                        FROM Art a";

                    var reader = cmd.ExecuteReader();

                    var arts = new List<Art>();

                    while (reader.Read())
                    {
                        arts.Add(new Art()
                        {
                            Id = DbUtils.GetInt(reader, "ArtId"),
                            AcnhApiId = DbUtils.GetInt(reader, "AcnhApiId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                            //HasFake = DbUtils.GetNull(reader, "HasFake"),
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
                    cmd.CommandText = @"INSERT INTO Art ( AcnhApiId, Name, ImageUrl, UserProfileId, HasFake, Obtained)
                                        OUTPUT INSERTED.ID
                                        VALUES (@AcnhApiId, @Name, @ImageUrl, @HasFake, @UserProfileId, @Obtained)";

                    DbUtils.AddParameter(cmd, "@AcnhApiId", art.Name);
                    DbUtils.AddParameter(cmd, "@Name", art.Name);
                    DbUtils.AddParameter(cmd, "@ImageUrl", art.ImageUrl);
                    DbUtils.AddParameter(cmd, "@UserProfileId", art.UserProfileId);
                    DbUtils.AddParameter(cmd, "@HasFake", art.HasFake);
                    DbUtils.AddParameter(cmd, "@oBtained", art.Obtained);


                    art.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
