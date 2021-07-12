using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Models
{
    public class BloggingRepository : IBloggingRepository
    {
        private readonly AppDbContext _appDbContext;

        public BloggingRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool DeleteBlog(int blogId)
        {
            try
            {
                Blog blogToDelete = this.GetBlogById(blogId);

                if (blogToDelete != null)
                {
                    _appDbContext.Blogs.Remove(blogToDelete);
                    _appDbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePost(int postId)
        {
            try
            {
                Post postToDelete = this.GetPostById(postId);

                if (postToDelete != null)
                {
                    _appDbContext.Posts.Remove(postToDelete);
                    _appDbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Blog> GetAllBlogs()
        {
            return _appDbContext.Blogs;
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _appDbContext.Posts;
        }

        public Blog GetBlogById(int blogId)
        {
            return _appDbContext
                    .Blogs
                    .Where(b => b.BlogId == blogId)
                    .FirstOrDefault();
        }

        public Post GetPostById(int postId)
        {
            return _appDbContext
                    .Posts
                    .Where(p => p.PostId == postId)
                    .FirstOrDefault();
        }

        public bool UpdateBlog(Blog blog)
        {
            try
            {
                Blog blogToUpdate = this.GetBlogById(blog.BlogId);
                if (blogToUpdate != null)
                {
                    blogToUpdate.Url = blog.Url;
                    _appDbContext.Entry(blogToUpdate).State = EntityState.Modified;
                    _appDbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool UpdatePost(Post post)
        {
            try
            {
                Post postToUpdate = this.GetPostById(post.PostId);
                if (postToUpdate != null)
                {
                    postToUpdate.Content = post.Content;
                    postToUpdate.Title = post.Title;

                    _appDbContext.Entry(postToUpdate).State = EntityState.Modified;
                    _appDbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
