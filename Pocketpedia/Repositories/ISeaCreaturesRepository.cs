using Pocketpedia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public interface ISeaCreaturesRepository
    {
        //Task<List<SeaCreatureFromApi>> SeaCreaturesFromAPi();
        void Add(SeaCreature seaCreatures);
    }
}