using SchoolMachine.Contracts.EntityRepositories;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.DataAccess.Entities.Models;

namespace SchoolMachine.Repository.Entities
{
    public class SchoolStudentRepository : RepositoryBase<SchoolStudent>, ISchoolStudentRepository
    {
        public SchoolStudentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
