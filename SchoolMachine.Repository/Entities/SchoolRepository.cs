using SchoolMachine.Contracts.EntityRepositories;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.DataAccess.Entities.Models;

namespace SchoolMachine.Repository.Entities
{
    public class SchoolRepository : RepositoryBase<School>, ISchoolRepository
    {
        public SchoolRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
