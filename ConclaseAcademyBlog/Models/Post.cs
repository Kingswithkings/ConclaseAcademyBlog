using ConclaseAcademyBlog.DbEntities;
using System;
using System.Collections.Generic;

namespace ConclaseAcademyBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Text {get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;


        public User User { get; set; }
        public ICollection<PostImage> PostImages { get; set; }
        public ICollection<PostVideo> PostVideos { get; set; }
        public ICollection<PostLike> PostLikes { get; set; }
        public ICollection<PostComment> PostComments {get; set; }


    }
}
