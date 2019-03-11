using SchoolMachine.DataAccess.Entities.Models.GeoLocation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolMachine.Contracts.EntityRepositories
{
    public interface ICountryRepository : IRepositoryBase<Country>
    {
        Task<IEnumerable<Country>> GetAllCountries();
    }
}
