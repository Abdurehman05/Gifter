using System.Linq;
using Microsoft.EntityFrameworkCore;
using Gifter.Data;
using Gifter.Models;

namespace Gifter.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public UserProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public UserProfile GetByFirebaseUserId(string firebaseUserId)
        {
            return _context.UserProfile
                    .FirstOrDefault(up => up.FirebaseUserId == firebaseUserId);
        }

        public void Add(UserProfile user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }
    }
}