using SchoolMachine.Contracts.EntityRepositories;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.DataAccess.Entities.Models.Geolocation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMachine.Repository.Entities
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(SchoolMachineContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return (await FindAll()).OrderBy(ow => ow.Name);
        }
    }
}
