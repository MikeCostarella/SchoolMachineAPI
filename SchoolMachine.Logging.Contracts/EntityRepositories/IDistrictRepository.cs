using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMachine.Contracts.EntityRepositories
{
    public interface IDistrictRepository : IRepositoryBase<District>
    {
        Task<IEnumerable<District>> GetAllDistricts();

        Task<District> GetDistrictById(Guid districtId);

        Task<IQueryable<School>> GetSchoolsByDistrictId(Guid districtId);

        Task CreateDistrict(District district);

        Task UpdateDistrict(District dbdistrict, District district);

        Task DeleteDistrict(District district);
    }
}
