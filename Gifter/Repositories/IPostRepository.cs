using Gifter.Models;
using System;
using System.Collections.Generic;

namespace Gifter.Repositories
{
    public interface IPostRepository
    {
        List<Post> GetAll();
        Post GetById(int id);
        List<Post> GetPostByUserProfileId(int id);
        void Add(Post post);
        void Update(Post post);
        public void Delete(int id);
        List<Post> Search(string searchTerm, bool oldestFirst);
        List<Post> FilterByDate(DateTime since, bool oldestFirst);
    }
}