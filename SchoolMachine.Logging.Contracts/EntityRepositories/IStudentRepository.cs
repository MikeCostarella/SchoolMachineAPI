using SchoolMachine.DataAccess.Entities.ExtendedModels;
using SchoolMachine.DataAccess.Entities.SchoolData.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolMachine.Contracts.EntityRepositories
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        Task<IEnumerable<Student>> GetAllStudents();

        Task<Student> GetStudentById(Guid studentId);

        Task<StudentExtended> GetStudentWithDetails(Guid studentId);

        Task CreateStudent(Student student);

        Task UpdateStudent(Student dbStudent, Student student);

        Task DeleteStudent(Student student);
    }
}
