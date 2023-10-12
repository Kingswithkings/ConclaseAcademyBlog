using ConclaseAcademyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConclaseAcademyBlog.Repository
{
    public class CommentRepository
    {
        private List<PostComment> comments;

        public CommentRepository()
        {
            comments = new List<PostComment>();
        }

        public PostComment AddComment(PostComment comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException(nameof(comment), "Comment cannot be null.");
            }

            comments.Add(comment);

            return comment;
        }

        public PostComment GetComment(int commentId)
        {
            return comments.FirstOrDefault(c => c.Id == commentId);
        }

        public List<PostComment> GetCommentsForPost(int postId)
        {
            return comments.Where(c => c.PostId == postId).ToList();
        }

        public List<PostComment> GetAllComments()
        {
            return comments.ToList();
        }

        public void UpdateComment(PostComment updatedComment)
        {
            var existingComment = comments.FirstOrDefault(c => c.Id == updatedComment.Id);

            if (existingComment != null)
            {
                existingComment.Content = updatedComment.Content;
                existingComment.DateUpdated = DateTime.UtcNow;
            }
        }

        public void DeleteComment(int commentId)
        {
            var commentToDelete = comments.FirstOrDefault(c => c.Id == commentId);

            if (commentToDelete != null)
            {
                comments.Remove(commentToDelete);
            }
        }
    }
}
