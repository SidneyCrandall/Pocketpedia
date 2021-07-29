using Pocketpedia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public interface IFishRepository
    {
        //Task<List<FishFromApi>> FishesFromAPi();
        void Add(Fish fish);
    }
}