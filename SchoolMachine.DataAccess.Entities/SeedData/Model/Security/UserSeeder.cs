using SchoolMachine.DataAccess.Entities.Models.Security;
using SchoolMachine.DataAccess.Entities.SeedData.Base;
using System;
using System.Collections.Generic;

namespace SchoolMachine.DataAccess.Entities.SeedData.Model.Security
{
    public class UserSeeder : DataSeederBase<User>
    {
        protected override void Initialize()
        {
            base.Initialize();
            Objects = new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    DateCreated = DateTime.UtcNow,
                    EmailAddress = "CostarellaMike@gmail.com",
                    FirstName = "Mike",
                    IsActive = true,
                    LastName = "Costarella",
                    MiddleName = "A.",
                    UserName = "MikeCostarella"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    DateCreated = DateTime.UtcNow,
                    EmailAddress = "JoePrincipal@ghs.com",
                    FirstName = "Joe",
                    IsActive = true,
                    LastName = "Principal",
                    MiddleName = "L.",
                    UserName = "JoePrincipal"
                }
            };
        }
    }
}
