using Pocketpedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public interface IVillagersRepository
    {
        Task<List<Villager>> VillagersFromApi();

        void Add(Villager villager);

        List<Villager> GetVillagersByUser(string firebaseUserId);
    }
}
