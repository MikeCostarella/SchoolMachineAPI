using AutoMapper;
using SchoolMachine.API.Models;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using System;

namespace SchoolMachine.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<District, DistrictDto>();
            CreateMap<DistrictDto, District>().BeforeMap((s, d) => d.Id = Guid.NewGuid());
            CreateMap<DistrictSchool, DistrictSchoolDto>();
            CreateMap<DistrictSchoolDto, DistrictSchool>().BeforeMap((s, d) => d.Id = Guid.NewGuid());
            CreateMap<School, SchoolDto>();
            CreateMap<SchoolDto, School>().BeforeMap((s, d) => d.Id = Guid.NewGuid());
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>().BeforeMap((s, d) => d.Id = Guid.NewGuid());
            CreateMap<SchoolStudent, SchoolStudentDto>();
            CreateMap<SchoolStudentDto, SchoolStudent>().BeforeMap((s, d) => d.Id = Guid.NewGuid());
        }
    }
}
