namespace ConclaseAcademyBlog.Models
{
    public class PostComment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
        public Post Post { get; set; }
    }
}
