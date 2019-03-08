using SchoolMachine.Contracts.EntityRepositories;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using SchoolMachine.DataAccess.Entities.SchoolData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMachine.Repository.Entities
{
    public class DistrictSchoolRepository : RepositoryBase<DistrictSchool>, IDistrictSchoolRepository
    {
        #region Constructors

        public DistrictSchoolRepository(SchoolMachineContext repositoryContext)
            : base(repositoryContext)
        {
        }

        #endregion Constructors

        #region Public Methods

        public async Task<IEnumerable<DistrictSchool>> GetAllDistrictSchools()
        {
            return await FindAll();
        }

        public async Task<DistrictSchool> GetDistrictSchoolById(Guid districtSchoolId)
        {
            return (await FindByCondition(districtSchool => districtSchool.Id.Equals(districtSchoolId)))
                    .DefaultIfEmpty(new DistrictSchool())
                    .FirstOrDefault();
        }

        public async Task<IEnumerable<DistrictSchool>> DistrictSchoolsBySchool(Guid schoolId)
        {
            return await FindByCondition(a => a.SchoolId.Equals(schoolId));
        }

        public async Task<IEnumerable<District>> DistrictsBySchool(Guid schoolId)
        {
            await Task.Delay(0);
            var districts = from districtShool in RepositoryContext.DistrictSchools
                          join district in RepositoryContext.Districts on districtShool.DistrictId equals district.Id
                          where (districtShool.SchoolId == schoolId)
                          select district;
            return districts;
        }

        public async Task<IEnumerable<DistrictSchool>> DistrictSchoolsByDistrict(Guid districtId)
        {
            return await FindByCondition(a => a.DistrictId.Equals(districtId));
        }

        public async Task CreateDistrictSchool(DistrictSchool districtSchool)
        {
            districtSchool.Id = Guid.NewGuid();
            await Create(districtSchool);
            await Save();
        }

        public async Task UpdateDistrictSchool(DistrictSchool dbDistrictSchool, DistrictSchool districtSchool)
        {
            dbDistrictSchool.DistrictId = districtSchool.DistrictId;
            dbDistrictSchool.EndDate = districtSchool.EndDate;
            dbDistrictSchool.SchoolId = districtSchool.SchoolId;
            dbDistrictSchool.StartDate = districtSchool.StartDate;
            await Update(dbDistrictSchool);
            await Save();
        }

        public async Task DeleteDistrictSchool(DistrictSchool districtSchool)
        {
            await Delete(districtSchool);
            await Save();
        }

        #endregion Public Methods
    }
}
