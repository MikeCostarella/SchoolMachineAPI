using SchoolMachine.Contracts.EntityRepositories;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.DataAccess.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolMachine.Repository.Entities
{
    public class SchoolStudentRepository : RepositoryBase<SchoolStudent>, ISchoolStudentRepository
    {
        #region Constructors

        public SchoolStudentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        #endregion Constructors

        #region Public Methods

        public IEnumerable<SchoolStudent> GetAllSchoolStudents()
        {
            return FindAll();
        }

        public SchoolStudent GetSchoolStudentById(Guid schoolStudentId)
        {
            return FindByCondition(schooltudent => schooltudent.Id.Equals(schoolStudentId))
                    .DefaultIfEmpty(new SchoolStudent())
                    .FirstOrDefault();
        }

        public IEnumerable<SchoolStudent> SchoolStudentsBySchool(Guid schoolId)
        {
            return FindByCondition(a => a.SchoolId.Equals(schoolId));
        }

        public IEnumerable<SchoolStudent> SchoolStudentsByStudent(Guid studentId)
        {
            return FindByCondition(a => a.StudentId.Equals(studentId));
        }

        #endregion Public Methods
    }
}
