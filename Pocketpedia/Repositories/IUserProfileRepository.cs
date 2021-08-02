using Pocketpedia.Models;
using System.Collections.Generic;

namespace Pocketpedia.Repositories
{
    public interface IUserProfileRepository
    {
        List<UserProfile> GetAll();
        UserProfile GetByFirebaseUserId(string firebaseUserId);
        UserProfile GetUserById(int id);   
        void Add(UserProfile userProfile);
        UserProfile GetByDisplayName(string displayName);
    }
}