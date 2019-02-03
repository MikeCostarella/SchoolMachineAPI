using SchoolMachine.DataAccess.Entities.Models;
using System;
using System.Collections.Generic;

namespace SchoolMachine.Contracts.EntityRepositories
{
    public interface ISchoolStudentRepository : IRepositoryBase<SchoolStudent>
    {
        IEnumerable<SchoolStudent> GetAllSchoolStudents();

        SchoolStudent GetSchoolStudentById(Guid schoolStudentId);

        IEnumerable<SchoolStudent> SchoolStudentsBySchool(Guid schoolId);

        IEnumerable<SchoolStudent> SchoolStudentsByStudent(Guid studentId);
    }
}
