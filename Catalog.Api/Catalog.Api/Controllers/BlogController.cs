using System.Collections.Generic;
using Catalog.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        private readonly IBloggingRepository _bloggingRepository;

        public BlogController(IBloggingRepository bloggingRepository)
        {
            _bloggingRepository = bloggingRepository;
        }

        // GET api/blog
        [HttpGet]
        public IEnumerable<Blog> GetBlogs()
        {
            return _bloggingRepository.GetAllBlogs();
        }

        // GET api/blog/5
        [HttpGet("{id}")]
        public Blog GetBlogById(int id)
        {
            return _bloggingRepository.GetBlogById(id);
        }

        // GET api/blog/GetPost/5
        [HttpGet("GetPost/{id}")]
        public Blog GetPostById(int id)
        {
            return _bloggingRepository.GetBlogById(id);
        }

        // POST api/blog
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/blog/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/blog/5
        [HttpDelete("{id}")]
        public void DeleteBlog(int id)
        {
            _bloggingRepository.DeleteBlog(id);
        }

        // DELETE api/blog/5
        [HttpDelete("{id}")]
        public void DeletePost(int id)
        {
            _bloggingRepository.DeleteBlog(id);
        }
    }
}
