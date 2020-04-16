namespace SchoolMachine.DataAccess.Entities.Authorization
{
    using System.Collections.Generic;

    public class Policy
    {
        public IEnumerable<RequiredClaim> Claims { get; set; }

        public string Name { get; set; }
    }
}