using SchoolMachine.DataAccess.Entities.ExtendedModels;
using SchoolMachine.DataAccess.Entities.SchoolData.Models;
using System;
using System.Collections.Generic;

namespace SchoolMachine.Contracts.EntityRepositories
{
    public interface ISchoolRepository : IRepositoryBase<School>
    {
        IEnumerable<School> GetAllSchools();

        School GetSchoolById(Guid schoolId);

        SchoolExtended GetSchoolWithDetails(Guid schoolId);

        void CreateSchool(School school);

        void UpdateSchool(School dbSchool, School school);

        void DeleteSchool(School school);
    }
}
