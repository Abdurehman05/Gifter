using Gifter.Data;
using Gifter.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Post> GetAll()
        {
            return _context.Post
                .Include(p => p.UserProfile)
                .Include(p => p.Comment)
                .Include(p => p.Comment)
                .Include(p => p.Comment)
                .Take(20)
                .OrderByDescending(p => p.DateCreated)
                .ToList();
        }

        public Post GetById(int id)
        {
            return _context.Post
                .Include(p => p.UserProfile)
                .Include(p => p.Comment)
                .FirstOrDefault(p => p.Id == id);
        }
        public List<Post> GetPostByUserProfileId(int id)
        {
            return _context.Post
                .Include(p => p.UserProfile)
                .Where(p => p.UserProfileId == id)
                .OrderBy(p => p.Title)
                .ToList();
        }
        public void Add(Post post)
        {
            _context.Add(post);
            _context.SaveChanges();
        }

        public void Update(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var post = GetById(id);
            _context.Post.Remove(post);
            _context.SaveChanges();
        }
        public List<Post> Search(string searchTerm, bool oldestFirst)
        {
            var query = _context.Post
                .Where(p => p.Title.Contains(searchTerm) || p.Caption.Contains(searchTerm))
                .Include(p => p.UserProfile);
            if (oldestFirst == true)
            {
                return query.OrderBy(p => p.DateCreated).ToList();
            }
            else
            {
                return query.OrderByDescending(p => p.DateCreated).ToList();
            }
        }

        public List<Post> FilterByDate(DateTime since, bool oldestFirst)
        {
            var query = _context.Post
                .Include(p => p.UserProfile)
                .Where(p => p.DateCreated > since);
            if (oldestFirst == true)
            {
                return query.OrderBy(p => p.DateCreated).ToList();
            }
            else
            {
                return query.OrderByDescending(p => p.DateCreated).ToList();
            }
        }
    }
}
