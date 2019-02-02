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

        #endregion Public Methods
    }
}
