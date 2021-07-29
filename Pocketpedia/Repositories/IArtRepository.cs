using Pocketpedia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public interface IArtRepository
    {
        //Task<List<ArtFromApi>> ArtsFromApi();
        void Add(Art art);
    }
}