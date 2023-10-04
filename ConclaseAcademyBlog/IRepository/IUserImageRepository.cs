using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ConclaseAcademyBlog.IRepository
{
    public interface IUserImageRepository
    {

        Task UploadImage(IFormFile file);
    }
}
