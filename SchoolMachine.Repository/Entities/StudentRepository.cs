using SchoolMachine.Contracts.EntityRepositories;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.DataAccess.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace SchoolMachine.Repository.Entities
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return FindAll()
                .OrderBy(ow => ow.LastName);
        }
    }
}
