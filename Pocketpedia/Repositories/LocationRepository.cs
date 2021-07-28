using Microsoft.Extensions.Configuration;
using Pocketpedia.Models;
using Pocketpedia.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public class LocationRepository : BaseRepository, ILocationRepository
    {
        public LocationRepository(IConfiguration config) : base(config) { }

        public List<Location> GetLocations()
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT l.Id,
                                               l.Name
                                        FROM Location l";

                    var reader = cmd.ExecuteReader();

                    var locations = new List<Location>();

                    while (reader.Read())
                    {
                        locations.Add(new Location()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name")
                        });
                    }

                    reader.Close();

                    return locations;
                }
            }
        }

        public Location GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT l.Id as LocationId,
                                               l.Name
                                        FROM Location l
                                        WHERE l.Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Location location = new Location()
                        {
                            Id = DbUtils.GetInt(reader, "LocationId"),
                            Name = DbUtils.GetString(reader, "Name")
                        };

                        reader.Close();

                        return location;
                    }

                    reader.Close();

                    return null;
                }
            }
        }
        
    }
}
