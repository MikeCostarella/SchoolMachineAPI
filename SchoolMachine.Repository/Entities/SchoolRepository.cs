using SchoolMachine.Contracts.EntityRepositories;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using SchoolMachine.DataAccess.Entities.Models.SchoolData.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMachine.Repository.Entities
{
    public class SchoolRepository : RepositoryBase<School>, ISchoolRepository
    {
        public SchoolRepository(SchoolMachineContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<IEnumerable<School>> GetAllSchools()
        {
            return (await FindAll()).OrderBy(ow => ow.Name);
        }

        public async Task<School> GetSchoolById(Guid schoolId)
        {
            return (await FindByCondition(student => student.Id.Equals(schoolId)))
                    .DefaultIfEmpty(new School())
                    .FirstOrDefault();
        }

        public async Task CreateSchool(School school)
        {
            school.Id = Guid.NewGuid();
            await Create(school);
            await Save();
        }

        public async Task UpdateSchool(School dbSchool, School school)
        {
            dbSchool.Map(school);
            await Update(dbSchool);
            await Save();
        }

        public async Task DeleteSchool(School school)
        {
            await Delete(school);
            await Save();
        }
    }
}
