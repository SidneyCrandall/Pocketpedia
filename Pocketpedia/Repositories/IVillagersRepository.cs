using Pocketpedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public interface IVillagersRepository
    {
        //Task<List<VillagerFromApi>> VillagersFromAPi()

        void Add(Villager villager);
    }
}
