using System.Collections.Generic;

namespace Catalog.Api.Models
{
    public interface IBloggingRepository
    {
        IEnumerable<Blog> GetAllBlogs();
        bool UpdateBlog(Blog blog);
        Blog GetBlogById(int blogId);
        bool DeleteBlog(int blogId);
        IEnumerable<Post> GetAllPosts();
        bool UpdatePost(Post post);
        Post GetPostById(int postId);
        bool DeletePost(int postId);
    }
}
