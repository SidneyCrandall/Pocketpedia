using Pocketpedia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public interface IBugsRepository
    {
        List<Bug> GetAllBugs();
        Task<List<BugFromApi>> BugsFromApi();
        void Add(Bug bug);     
    }
}