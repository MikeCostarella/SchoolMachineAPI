using SchoolMachine.Contracts.EntityRepositories;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.DataAccess.Entities.ExtendedModels;
using SchoolMachine.DataAccess.Entities.Extensions;
using SchoolMachine.DataAccess.Entities.SchoolData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMachine.Repository.Entities
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        #region Constructors

        public StudentRepository(SchoolMachineContext repositoryContext)
            : base(repositoryContext)
        {
        }

        #endregion Constructors

        #region Public Methods

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return (await FindAll()).OrderBy(ow => ow.LastName);
        }

        public async Task<Student> GetStudentById(Guid studentId)
        {
            return (await FindByCondition(student => student.Id.Equals(studentId)))
                    .DefaultIfEmpty(new Student())
                    .FirstOrDefault();
        }

        public async Task<StudentExtended> GetStudentWithDetails(Guid studentId)
        {
            return new StudentExtended(await GetStudentById(studentId))
            {
                Schools = RepositoryContext.SchoolStudents
                    .Where(a => a.StudentId == studentId)
            };
        }

        public async Task CreateStudent(Student student)
        {
            student.Id = Guid.NewGuid();
            await Create(student);
            await Save();
        }

        public async Task UpdateStudent(Student dbStudent, Student student)
        {
            dbStudent.Map(student);
            await Update(dbStudent);
            await Save();
        }

        public async Task DeleteStudent(Student student)
        {
            await Delete(student);
            await Save();
        }

        #endregion Public Methods
    }
}
