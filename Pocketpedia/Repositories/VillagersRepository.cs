using Microsoft.Extensions.Configuration;
using Pocketpedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public class VillagersRepository : BaseRepository, IVillagersRepository
    {
        public VillagersRepository(IConfiguration configuration) : base(configuration) { }

        public void Add(Villagers villager)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Villagers (Name, Birthday, UserProfileId)
                                    OUTPUT INSERTED.ID 
                                    VALUES (@AcnhApiId, @Name, @Birthday, @UserProfileId)";

                    cmd.Parameters.AddWithValue("@Name", villager.Name);
                    cmd.Parameters.AddWithValue("@Birthday", villager.Birthday);
                    cmd.Parameters.AddWithValue("@UserProfileId", villager.UserProfileId);

                    villager.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}