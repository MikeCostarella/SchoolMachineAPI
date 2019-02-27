using SchoolMachine.DataAccess.Entities.SchoolData.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolMachine.Contracts.EntityRepositories
{
    public interface ISchoolStudentRepository : IRepositoryBase<SchoolStudent>
    {
        Task<IEnumerable<SchoolStudent>> GetAllSchoolStudents();

        Task<SchoolStudent> GetSchoolStudentById(Guid schoolStudentId);

        Task<IEnumerable<SchoolStudent>> SchoolStudentsBySchool(Guid schoolId);

        Task<IEnumerable<SchoolStudent>> SchoolStudentsByStudent(Guid studentId);

        Task DeleteSchoolStudent(SchoolStudent schoolStudent);

        Task UpdateSchoolStudent(SchoolStudent dbSchoolStudent, SchoolStudent schoolStudent);

        Task CreateSchoolStudent(SchoolStudent schoolStudent);
    }
}
