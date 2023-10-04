using ConclaseAcademyBlog.DTO.RequestDto;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ConclaseAcademyBlog.Models;
using ConclaseAcademyBlog.IRepository;

namespace ConclaseAcademyBlog.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
      
       // private readonly FirebaseStorage _storage;
        private readonly StorageClient _storageClient;
        private readonly IPostRepository _postRepository;

        public BlogPostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
             
            _storageClient = StorageClient.Create();
            //_storage = new FirebaseStorage("YOUR_STORAGE_BUCKET");
        }
        [HttpPost("create/blogpost")]
        //Route("create/blogpost")
        public async Task<IActionResult> createblogpost(BlogPost blogPost)
        {
            try
            {
                if (blogPost.Text.Length>100)
                {
                    return BadRequest("Text Length Greater Than 100");
                }

                if (blogPost.Images.Count>4)
                {
                    return BadRequest("Images More Than 4");
                }
                var posts = _postRepository.GetAllPosts();

                List<string> Images = new List<string>();
                List<string> Videos = new List<string>();
                string bucketName = "conclaseacademyblog.appspot.com";
                foreach (var item in blogPost.Images)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(item.FileName);
                    var objectName = $"uploads/{fileName}";

                    // Upload the file to Firebase Storage
                    using (var memoryStream = new MemoryStream())
                    {
                        await item.CopyToAsync(memoryStream);
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        await _storageClient.UploadObjectAsync(bucketName, objectName, null, memoryStream);
                    }

                    // Return the Firebase Storage URL for the uploaded file
                    var storageUrl = $"https://storage.googleapis.com/{bucketName}/{objectName}";

                    Images.Add(storageUrl);

                }



                foreach (var item in blogPost.Videos)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(item.FileName);
                    var objectName = $"uploads/{fileName}";

                    // Upload the file to Firebase Storage
                    using (var memoryStream = new MemoryStream())
                    {
                        await item.CopyToAsync(memoryStream);
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        await _storageClient.UploadObjectAsync(bucketName, objectName, null, memoryStream);

                      
                    }

                    // Return the Firebase Storage URL for the uploaded file
                    var storageUrl = $"https://storage.googleapis.com/{bucketName}/{objectName}";

                    Videos.Add(storageUrl);
                }

                Post post = new Post();
                post.Text = blogPost.Text;
                post.PostImages = (ICollection<PostImage>)Images;
                post.PostVideos = (ICollection<PostVideo>)Videos;
 
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

            
        
    }
}
