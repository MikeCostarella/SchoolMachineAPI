using AutoMapper;
using SchoolMachine.API.Dtos;
using SchoolMachine.DataAccess.Entities.Models.Security;

namespace SchoolMachine.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
