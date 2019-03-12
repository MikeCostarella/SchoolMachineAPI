using SchoolMachine.DataAccess.Entities.Models.Security;
using SchoolMachine.DataAccess.Entities.SeedData.Base;
using System;
using System.Collections.Generic;

namespace SchoolMachine.DataAccess.Entities.SeedData.Model.Security
{
    public class RoleSeeder : DataSeederBase<Role>
    {
        protected override void Initialize()
        {
            base.Initialize();
            Objects = new List<Role>
            {
                new Role { Id = Guid.NewGuid(), Name = "System Administrator", Description = "Total access to all other roles", DateCreated = DateTime.UtcNow },
                new Role { Id = Guid.NewGuid(), Name = "Can Create District Information", Description = "Can Create District Information", DateCreated = DateTime.UtcNow },
                new Role { Id = Guid.NewGuid(), Name = "Can Read District Information", Description = "Can Read District Information", DateCreated = DateTime.UtcNow },
                new Role { Id = Guid.NewGuid(), Name = "Can Update District Information", Description = "Can View District Information", DateCreated = DateTime.UtcNow },
                new Role { Id = Guid.NewGuid(), Name = "Can Delete District Information", Description = "Can Delete District Information", DateCreated = DateTime.UtcNow },
                new Role { Id = Guid.NewGuid(), Name = "Can Create School Information", Description = "Can Create School Information", DateCreated = DateTime.UtcNow },
                new Role { Id = Guid.NewGuid(), Name = "Can Read School Information", Description = "Can Read School Information", DateCreated = DateTime.UtcNow },
                new Role { Id = Guid.NewGuid(), Name = "Can Update School Information", Description = "Can View School Information", DateCreated = DateTime.UtcNow },
                new Role { Id = Guid.NewGuid(), Name = "Can Delete School Information", Description = "Can Delete School Information", DateCreated = DateTime.UtcNow },
                new Role { Id = Guid.NewGuid(), Name = "Can Create Student Information", Description = "Can Create Student Information", DateCreated = DateTime.UtcNow },
                new Role { Id = Guid.NewGuid(), Name = "Can Read Student Information", Description = "Can Read Student Information", DateCreated = DateTime.UtcNow },
                new Role { Id = Guid.NewGuid(), Name = "Can Update Student Information", Description = "Can View Student Information", DateCreated = DateTime.UtcNow },
                new Role { Id = Guid.NewGuid(), Name = "Can Delete Student Information", Description = "Can Delete Student Information", DateCreated = DateTime.UtcNow }
            };
        }
    }
}
