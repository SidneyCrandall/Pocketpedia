using Pocketpedia.Models;
using System.Collections.Generic;

namespace Pocketpedia.Repositories
{
    public interface ILocationRepository
    {
       public List<Location> GetLocations();
    }
}