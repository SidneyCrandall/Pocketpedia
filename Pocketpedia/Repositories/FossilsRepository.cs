using Microsoft.Extensions.Configuration;
using Pocketpedia.Models;
using Pocketpedia.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public class FossilsRepository : BaseRepository, IFossilsRepository
    {
        public FossilsRepository(IConfiguration configuration) : base(configuration) { }

        public void Add(Fossils fossils)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Fossils (Name, ImageUrl, UserProfileId, Discvored)
                                        OUTPUT INSERTED.ID
                                        VALUES (@Name, @ImageUrl, @UserProfileId, @Discvored)";

                    DbUtils.AddParameter(cmd, "@Name", fossils.Name);
                    DbUtils.AddParameter(cmd, "@Content", fossils.ImageUrl);
                    DbUtils.AddParameter(cmd, "@UserProfileId", fossils.UserProfileId);
                    DbUtils.AddParameter(cmd, "@PublishDateTime", fossils.Discovered);
                }
            }
        }
    }
}
