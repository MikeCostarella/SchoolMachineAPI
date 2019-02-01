using SchoolMachine.Contracts.EntityRepositories;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.DataAccess.Entities.ExtendedModels;
using SchoolMachine.DataAccess.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolMachine.Repository.Entities
{
    public class SchoolRepository : RepositoryBase<School>, ISchoolRepository
    {
        public SchoolRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<School> GetAllSchools()
        {
            return FindAll()
                .OrderBy(ow => ow.Name);
        }

        public School GetSchoolById(Guid schoolId)
        {
            return FindByCondition(student => student.Id.Equals(schoolId))
                    .DefaultIfEmpty(new School())
                    .FirstOrDefault();
        }

        public SchoolExtended GetSchoolWithDetails(Guid studentId)
        {
            return new SchoolExtended(GetSchoolById(studentId))
            {
                Students = RepositoryContext.SchoolStudents
                    .Where(a => a.SchoolId == studentId)
            };
        }
    }
}
