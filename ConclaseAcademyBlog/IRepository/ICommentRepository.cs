using System.Collections.Generic;
using System;

namespace ConclaseAcademyBlog.IRepository
{
    public interface ICommentRepository
    {
        // Adds a new comment and returns the added comment.
        ICommentRepository AddComment(ICommentRepository comment);

        // Retrieves a comment by its unique ID.
        ICommentRepository GetComment(Guid commentId);

        // Retrieves all comments for a specific blog post by its ID.
        List<ICommentRepository> GetCommentsForPost(Guid postId);

        // Retrieves all comments in the system.
        List<ICommentRepository> GetAllComments();

        // Updates an existing comment with new content.
        void UpdateComment(ICommentRepository updatedComment);

        // Deletes a comment by its ID.
        void DeleteComment(Guid commentId);
    }
}
