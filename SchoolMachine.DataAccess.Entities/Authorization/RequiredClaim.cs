namespace SchoolMachine.DataAccess.Entities.Authorization
{
    using System.Collections.Generic;

    public class RequiredClaim
    {
        public CustomClaimTypes ClaimType { get; set; }

        public IEnumerable<string> ClaimValues { get; set; }
    }
}