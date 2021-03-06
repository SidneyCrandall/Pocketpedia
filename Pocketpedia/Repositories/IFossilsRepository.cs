using Pocketpedia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public interface IFossilsRepository
    {
        Task<List<Fossil>> FossilsFromApi();
        void Add(Fossil fossils);
        List<Fossil> GetFossilsByUserId(string firebaseUserId);
    }
}