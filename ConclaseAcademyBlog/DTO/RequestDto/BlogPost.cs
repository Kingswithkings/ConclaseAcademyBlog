using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ConclaseAcademyBlog.DTO.RequestDto
{
    public class BlogPost
    {
        public string Text { get; set; }
        public List<IFormFile> Images { get; set; }
        public List<IFormFile> Videos { get; set; }

    }
}
