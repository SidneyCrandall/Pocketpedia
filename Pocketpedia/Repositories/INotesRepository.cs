using Pocketpedia.Models;
using System.Collections.Generic;

namespace Pocketpedia.Repositories
{
    public interface INotesRepository
    {
        void Add(Notes notes);
        void Delete(int notesId);
        List<Notes> GetAll();
        Notes GetNotesById(int id);
        List<Notes> GetUserNotes(string FirebaseUserId);
        void Update(Notes notes);
    }
}