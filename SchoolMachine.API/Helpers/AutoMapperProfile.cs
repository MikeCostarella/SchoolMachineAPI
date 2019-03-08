using AutoMapper;
using SchoolMachine.API.Dtos;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using SchoolMachine.DataAccess.Entities.Models.Security;
using System;

namespace SchoolMachine.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<School, SchoolDto>();
            CreateMap<SchoolDto, School>().BeforeMap((s, d) => d.Id = Guid.NewGuid());
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>().BeforeMap((s, d) => d.Id = Guid.NewGuid());
            CreateMap<SchoolStudent, SchoolStudentDto>();
            CreateMap<SchoolStudentDto, SchoolStudent>().BeforeMap((s, d) => d.Id = Guid.NewGuid());
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>().BeforeMap((s, d) => d.Id = Guid.NewGuid());
        }
    }
}
