using Pocketpedia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public interface IFishRepository
    {
        List<Fish> GetAllFish();
        Task<List<Fish>> FishesFromApi();
        void Add(Fish fish);
        List<Fish> GetFishByUserId(string firebaseUserId);
    }
}