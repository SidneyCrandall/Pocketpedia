using Pocketpedia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public interface IFishRepository
    {
        Task<List<Fish>> FishesFromAPi();
        void Add(Fish fish);
        List<Fish> GetAllFish();
    }
}