using SchoolMachine.DataAccess.Entities.Models.Geolocation;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMachine.Contracts.EntityRepositories
{
    public interface IStateRepository : IRepositoryBase<State>
    {
        Task<IQueryable<State>> GetStatesByCountryId(Guid districtId);
    }
}
