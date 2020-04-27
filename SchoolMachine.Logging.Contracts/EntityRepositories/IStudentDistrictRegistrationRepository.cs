using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolMachine.Contracts.EntityRepositories
{
    public interface IStudentDistrictRegistrationRepository : IRepositoryBase<StudentDistrictRegistration>
    {
        Task<IEnumerable<StudentDistrictRegistration>> GetAllStudentDistrictRegistrations();
    }
}
