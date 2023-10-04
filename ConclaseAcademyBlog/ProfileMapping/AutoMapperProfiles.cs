using AutoMapper;
using ConclaseAcademyBlog.DbEntities;
using ConclaseAcademyBlog.DTO.ResponseDto;

namespace ConclaseAcademyBlog.ProfileMapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, GetUserProfileResponseDto>().ReverseMap();
        }
    }
}
