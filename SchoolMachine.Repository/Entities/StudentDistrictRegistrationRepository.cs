using System.Collections.Generic;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using SchoolMachine.Contracts.EntityRepositories;
using SchoolMachine.DataAccess.Entities;
using System.Threading.Tasks;
using System.Linq;

namespace SchoolMachine.Repository.Entities
{
    public class StudentDistrictRegistrationRepository : RepositoryBase<StudentDistrictRegistration>, IStudentDistrictRegistrationRepository
    {
        public StudentDistrictRegistrationRepository(SchoolMachineContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<IEnumerable<StudentDistrictRegistration>> GetAllStudentDistrictRegistrations()
        {
            return (await FindAll()).OrderBy(ow => ow.StudentLastName);
        }
    }
}