using Microsoft.Extensions.Configuration;
using Pocketpedia.Models;
using Pocketpedia.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public class ArtRepository : BaseRepository, IArtRepository
    {
        public ArtRepository(IConfiguration configuration) : base(configuration) { }

        public void Add(Art art)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Art ( Name, ImageUrl, IsReal, UserProfileId, Obtained)
                                        OUTPUT INSERTED.ID
                                        VALUES (@Name, @ImageUrl, @IsReal, @UserProfileId, @Obtained)";

                    DbUtils.AddParameter(cmd, "@Name", art.Name);
                    DbUtils.AddParameter(cmd, "@ImageUrl", art.ImageUrl);
                    DbUtils.AddParameter(cmd, "@IsReal", art.IsReal);
                    DbUtils.AddParameter(cmd, "@UserProfileId", art.UserProfileId);
                    DbUtils.AddParameter(cmd, "@oBtained", art.Obtained);


                    art.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
