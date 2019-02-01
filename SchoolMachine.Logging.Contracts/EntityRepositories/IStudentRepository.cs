using SchoolMachine.DataAccess.Entities.Models;
using System.Collections.Generic;

namespace SchoolMachine.Contracts.EntityRepositories
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        IEnumerable<Student> GetAllStudents();
    }
}
