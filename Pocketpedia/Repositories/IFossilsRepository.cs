using Pocketpedia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public interface IFossilsRepository
    {
        List<Fossil> GetFossils();
        Task<List<Fossil>> FossilsFromApi();
        void Add(Fossil fossils);
    }
}