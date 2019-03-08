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
    public class DistrictRepository : RepositoryBase<District>, IDistrictRepository
    {
        public DistrictRepository(SchoolMachineContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<IEnumerable<District>> GetAllDistricts()
        {
            return (await FindAll()).OrderBy(ow => ow.Name);
        }

        public async Task<District> GetDistrictById(Guid districtId)
        {
            return (await FindByCondition(district => district.Id.Equals(districtId)))
                    .DefaultIfEmpty(new District())
                    .FirstOrDefault();
        }

        public async Task CreateDistrict(District district)
        {
            district.Id = Guid.NewGuid();
            await Create(district);
            await Save();
        }

        public async Task UpdateDistrict(District dbDistrict, District district)
        {
            dbDistrict.Map(district);
            await Update(dbDistrict);
            await Save();
        }

        public async Task DeleteDistrict(District district)
        {
            await Delete(district);
            await Save();
        }
    }
}
