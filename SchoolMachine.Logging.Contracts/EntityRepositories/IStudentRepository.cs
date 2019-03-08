using SchoolMachine.DataAccess.Entities.SchoolData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMachine.Contracts.EntityRepositories
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        Task<IEnumerable<Student>> GetAllStudents();

        Task<Student> GetStudentById(Guid studentId);

        Task<IQueryable<School>> GetSchoolsByStudentId(Guid studentId);

        Task<IQueryable<Student>> GetStudentsBySchoolId(Guid schoolId);

        Task CreateStudent(Student student);

        Task UpdateStudent(Student dbStudent, Student student);

        Task DeleteStudent(Student student);
    }
}
