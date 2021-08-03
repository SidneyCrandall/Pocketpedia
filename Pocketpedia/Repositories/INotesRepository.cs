using Pocketpedia.Models;
using System.Collections.Generic;

namespace Pocketpedia.Repositories
{
    public interface INotesRepository
    {
        List<Notes> GetUserNotes(string FirebaseUserId);
        Notes GetNotesById(int id);
        void Add(Notes notes);
        void UpdateNotes(Notes notes);
        void Delete(int id);
    }
}