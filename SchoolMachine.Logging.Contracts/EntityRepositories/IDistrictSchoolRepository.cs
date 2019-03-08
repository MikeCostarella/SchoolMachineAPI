using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolMachine.Contracts.EntityRepositories
{
    public interface IDistrictSchoolRepository : IRepositoryBase<DistrictSchool>
    {
        Task<IEnumerable<DistrictSchool>> GetAllDistrictSchools();

        Task<DistrictSchool> GetDistrictSchoolById(Guid districtSchoolId);

        Task<IEnumerable<DistrictSchool>> DistrictSchoolsByDistrict(Guid districtId);

        Task<IEnumerable<District>> DistrictsBySchool(Guid districtId);

        Task<IEnumerable<DistrictSchool>> DistrictSchoolsBySchool(Guid districtId);

        Task DeleteDistrictSchool(DistrictSchool districtSchool);

        Task UpdateDistrictSchool(DistrictSchool dbDistrictSchool, DistrictSchool schoolStudent);

        Task CreateDistrictSchool(DistrictSchool districtSchool);
    }
}
