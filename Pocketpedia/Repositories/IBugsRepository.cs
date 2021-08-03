using Pocketpedia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public interface IBugsRepository
    {
        Task<List<Bug>> BugsFromApi();
        void Add(Bug bug);
        List<Bug> GetBugsByUserId(string firebaseUserId);
    }
}