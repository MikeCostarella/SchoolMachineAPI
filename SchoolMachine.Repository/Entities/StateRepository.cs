using SchoolMachine.Contracts.EntityRepositories;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.DataAccess.Entities.Models.Geolocation;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMachine.Repository.Entities
{
    public class StateRepository : RepositoryBase<State>, IStateRepository
    {
        public StateRepository(SchoolMachineContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<IQueryable<State>> GetStatesByCountryId(Guid countryId)
        {
            await Task.Delay(0);
            var states = from state in RepositoryContext.States
                          where (state.CountryId == countryId)
                          select state;
            return states.OrderBy(state => state.Name);
        }
    }
}
