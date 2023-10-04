using System;

namespace ConclaseAcademyBlog.Models
{
    public class PostImage
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Url { get; set; }
        public DateTime DateCreated {get; set; }

        public Post Post { get; set; }
    }
}
