using AutoMapper;
using SchoolMachine.API.Dtos;
using SchoolMachine.DataAccess.Entities.Models.Security;
using SchoolMachine.DataAccess.Entities.SchoolData.Models;

namespace SchoolMachine.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<School, SchoolDto>();
            CreateMap<SchoolDto, School>();
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
            CreateMap<SchoolStudent, SchoolStudentDto>();
            CreateMap<SchoolStudentDto, SchoolStudent>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
