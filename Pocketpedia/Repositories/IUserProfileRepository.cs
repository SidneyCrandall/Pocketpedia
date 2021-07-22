namespace Pocketpedia.Repositories
{
    public interface IUserProfileRepository
    {
        void Add(UserProfile userProfile);
        void Delete(int id);
        System.Collections.Generic.List<UserProfile> GetAll();
        UserProfile GetByFirebaseUserId(string firebaseUserId);
        UserProfile GetUserById(int id);
        UserProfile GetUserWithVideos(int id);
        void Update(UserProfile userProfile);
    }
}