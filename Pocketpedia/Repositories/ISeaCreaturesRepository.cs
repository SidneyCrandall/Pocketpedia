using Pocketpedia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public interface ISeaCreaturesRepository
    {
        Task<List<SeaCreature>> SeaCreaturesFromApi();
        void Add(SeaCreature SeaCreature);
        List<SeaCreature> GetSeaCreatureByUserId(string firebaseUserId);
    }
}