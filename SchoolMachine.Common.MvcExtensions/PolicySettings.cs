using SchoolMachine.DataAccess.Entities.Authorization;
using System.Collections.Generic;

namespace SchoolMachine.API.Settings
{
    public class PolicySettings
    {
        public IEnumerable<Policy> Policies { get; set; }
    }
}