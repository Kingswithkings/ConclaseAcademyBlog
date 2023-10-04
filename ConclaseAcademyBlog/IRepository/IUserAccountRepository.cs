using ConclaseAcademyBlog.DTO.Generic;
using ConclaseAcademyBlog.DTO.RequestDto;
using ConclaseAcademyBlog.DTO.ResponseDto;
using System.Threading.Tasks;

namespace ConclaseAcademyBlog.IRepository
{
    public interface IUserAccountRepository
    {
        Task<Response<UserRegistrationResponseDto>> RegisterAsync(UserRegistrationRequestDto model);

        Task<Response<bool>> UpdateAsync(string userId, UpdateUserRequestDto model);

        Task<Response<LoginResponseDto>> LoginAsync(LoginRequestDto model);

        Task<Response<bool>> ChangePasswordAsync(ChangePasswordRequestDto model);
    }
}
