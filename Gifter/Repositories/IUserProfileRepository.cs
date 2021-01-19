using Gifter.Models;

namespace Gifter.Repositories
{
    public interface IUserProfileRepository
    {
        void Add(UserProfile user);
        UserProfile GetByFirebaseUserId(string firebaseUserId);
    }
}