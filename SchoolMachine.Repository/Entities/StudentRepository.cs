using SchoolMachine.Contracts.EntityRepositories;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.DataAccess.Entities.ExtendedModels;
using SchoolMachine.DataAccess.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolMachine.Repository.Entities
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        #region Constructors

        public StudentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        #endregion Constructors

        #region Public Methods

        public IEnumerable<Student> GetAllStudents()
        {
            return FindAll()
                .OrderBy(ow => ow.LastName);
        }

        public Student GetStudentById(Guid studentId)
        {
            return FindByCondition(student => student.Id.Equals(studentId))
                    .DefaultIfEmpty(new Student())
                    .FirstOrDefault();
        }

        public StudentExtended GetStudentWithDetails(Guid studentId)
        {
            return new StudentExtended(GetStudentById(studentId))
            {
                Schools = RepositoryContext.SchoolStudents
                    .Where(a => a.StudentId == studentId)
            };
        }

        #endregion Public Methods
    }
}
