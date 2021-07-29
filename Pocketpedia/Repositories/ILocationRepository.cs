using Pocketpedia.Models;
using System.Collections.Generic;

namespace Pocketpedia.Repositories
{
    public interface ILocationRepository
    {
        Location GetById(int id);
        public List<Location> GetLocations();
    }
}