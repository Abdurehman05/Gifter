using Gifter.Data;
using Gifter.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public UserProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UserProfile> GetAll()

        {
            return _context.UserProfile
                .Include(u => u.Comments)
                .Include(u => u.Posts)
                .ToList();
        }

        public UserProfile GetById(int id)
        {
            return _context.UserProfile.FirstOrDefault(u => u.Id == id);
        }

        public void Add(UserProfile userProfile)
        {
            _context.Add(userProfile);
            _context.SaveChanges();
        }

        public void Update(UserProfile userProfile)
        {
            _context.Entry(userProfile).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var userToDelete = _context.UserProfile
                .Where(u => u.Id == id) // Find the user by id
                .Include(c => c.Comments) //Comments made by users
                .Include(c => c.Posts) // Postes written by user
                .ThenInclude(p => p.Comment); // All comments on posts they have written

            _context.UserProfile.RemoveRange(userToDelete);
            _context.SaveChanges();
        }
    }
}
