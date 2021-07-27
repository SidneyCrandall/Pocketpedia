using Microsoft.Extensions.Configuration;
using Pocketpedia.Models;
using Pocketpedia.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public class FishRepository : BaseRepository, IFishRepository
    {
        public FishRepository(IConfiguration configuration) : base(configuration) { }

        public void Add(Fish fish)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Fish (Name, ImageUrl, LocationId, SeasonAvailabiltyId, UserProfileId, Caught)
                                        OUTPUT INSERTED.ID
                                        VALUES (@Name, @ImageUrl, @LocationId, @SeasonAvailabiltyId, @UserProfileId, @Caught)";

                    DbUtils.AddParameter(cmd, "@Name", fish.Name);
                    DbUtils.AddParameter(cmd, "@ImageUrl", fish.ImageUrl);
                    DbUtils.AddParameter(cmd, "@LocationId", fish.LocationId);
                    DbUtils.AddParameter(cmd, "@SeasonAvailabiltyId", fish.SeasonAvailabiltyId);
                    DbUtils.AddParameter(cmd, "@UserProfileId", fish.UserProfileId);
                    DbUtils.AddParameter(cmd, "@Caught", fish.Caught);
                }
            }
        }
    }
}
