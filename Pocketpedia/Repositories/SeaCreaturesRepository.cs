using Microsoft.Extensions.Configuration;
using Pocketpedia.Models;
using Pocketpedia.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public class SeaCreaturesRepository : BaseRepository, ISeaCreaturesRepository
    {
        public SeaCreaturesRepository(IConfiguration configuration) : base(configuration) { }

        public void Add(SeaCreatures seaCreatures)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Fossils (Name, ImageUrl, UserProfileId, Caught)
                                        OUTPUT INSERTED.ID
                                        VALUES (@Name, @ImageUrl, @UserProfileId, @Caught)";

                    DbUtils.AddParameter(cmd, "@Name", seaCreatures.Name);
                    DbUtils.AddParameter(cmd, "@ImageUrl", seaCreatures.ImageUrl);
                    DbUtils.AddParameter(cmd, "@UserProfileId", seaCreatures.UserProfileId);
                    DbUtils.AddParameter(cmd, "@Caught", seaCreatures.Caught);

                    seaCreatures.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}