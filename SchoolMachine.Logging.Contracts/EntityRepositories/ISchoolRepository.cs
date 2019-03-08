using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolMachine.Contracts.EntityRepositories
{
    public interface ISchoolRepository : IRepositoryBase<School>
    {
        Task<IEnumerable<School>> GetAllSchools();

        Task<School> GetSchoolById(Guid schoolId);

        Task CreateSchool(School school);

        Task UpdateSchool(School dbSchool, School school);

        Task DeleteSchool(School school);
    }
}
