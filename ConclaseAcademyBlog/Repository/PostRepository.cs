using ConclaseAcademyBlog.Data;
using ConclaseAcademyBlog.IRepository;
using ConclaseAcademyBlog.Models; // You should include the appropriate namespace for your Post model
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConclaseAcademyBlog.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context; // Assuming you are using Entity Framework Core

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts.ToList();
        }

        public Post GetPostById(int postId)
        {
            return _context.Posts.FirstOrDefault(p => p.Id == postId);
        }

        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();
        }

        public void DeletePost(int postId)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == postId);
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
           
        }

        public async Task<IEnumerable<Post>> GetPosts(Func<T, bool> predicate) 
        {
            var posts = await _context.Posts.Where(predicate);
            return posts;
        }
    }

}
