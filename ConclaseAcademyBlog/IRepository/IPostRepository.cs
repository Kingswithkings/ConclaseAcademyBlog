using System;
using System.Collections.Generic;
using ConclaseAcademyBlog.Models; // You should include the appropriate namespace for your Post model

namespace ConclaseAcademyBlog.IRepository
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAllPosts();

        IEnumerable<Post> GetPosts (Func<Post, bool> predicate);
        Post GetPostById(int postId);
        void AddPost(Post post);
        void UpdatePost(Post post);
        void DeletePost(int postId);
    }
}
