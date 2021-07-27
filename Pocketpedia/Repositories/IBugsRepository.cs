using Pocketpedia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public interface IBugsRepository
    {
        List<Bugs> GetAllBugs();
        //Task<List<BugList>>;
        void Add(Bugs bug);     
    }
}