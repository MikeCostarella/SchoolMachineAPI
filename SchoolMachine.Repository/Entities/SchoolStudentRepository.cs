using SchoolMachine.Contracts.EntityRepositories;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.DataAccess.Entities.SchoolData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMachine.Repository.Entities
{
    public class SchoolStudentRepository : RepositoryBase<SchoolStudent>, ISchoolStudentRepository
    {
        #region Constructors

        public SchoolStudentRepository(SchoolMachineContext repositoryContext)
            : base(repositoryContext)
        {
        }

        #endregion Constructors

        #region Public Methods

        public async Task<IEnumerable<SchoolStudent>> GetAllSchoolStudents()
        {
            return await FindAll();
        }

        public async Task<SchoolStudent> GetSchoolStudentById(Guid schoolStudentId)
        {
            return (await FindByCondition(schooltudent => schooltudent.Id.Equals(schoolStudentId)))
                    .DefaultIfEmpty(new SchoolStudent())
                    .FirstOrDefault();
        }

        public async Task<IEnumerable<SchoolStudent>> SchoolStudentsBySchool(Guid schoolId)
        {
            return await FindByCondition(a => a.SchoolId.Equals(schoolId));
        }

        public async Task<IEnumerable<SchoolStudent>> SchoolStudentsByStudent(Guid studentId)
        {
            return await FindByCondition(a => a.StudentId.Equals(studentId));
        }

        #endregion Public Methods
    }
}
