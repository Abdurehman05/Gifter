using Gifter.Models;
using Gifter.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_postRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var post = _postRepository.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpGet("getbyuser/{id}")]
        public IActionResult GetByUser(int id)
        {
            return Ok(_postRepository.GetPostByUserProfileId(id));
        }
        [HttpPost]
        public IActionResult Add(Post post)
        {
            post.DateCreated = DateTime.Now;

            _postRepository.Add(post);
            return Ok(post);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }
            var existingPost = _postRepository.GetById(id);
            if (existingPost == null)
            {
                return NotFound();
            }
            _postRepository.Update(post);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingPost = _postRepository.GetById(id);
            if (existingPost == null)
            {
                return NotFound();
            }
            _postRepository.Delete(id);
            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult Search(string criterion, bool oldestFirst)
        {
            if (criterion == null)
                return Ok(_postRepository.GetAll());

            var posts = _postRepository.Search(criterion, oldestFirst);
            return Ok(posts);
        }
        [HttpGet("hottest")]
        public IActionResult FilterByDate(DateTime since, bool oldestFirst)
        {
            return Ok(_postRepository.FilterByDate(since, oldestFirst));
        }
    }
}
