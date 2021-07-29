using Pocketpedia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public interface IFossilsRepository
    {
        //Task<List<FossilFromApi>> FossilsFromAPi();
        void Add(Fossil fossils);
    }
}