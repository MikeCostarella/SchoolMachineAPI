using SchoolMachine.DataAccess.Entities.Models.Security;
using SchoolMachine.DataAccess.Entities.SeedData.Base;
using System;
using System.Collections.Generic;

namespace SchoolMachine.DataAccess.Entities.SeedData.Model.Security
{
    public class GroupSeeder : DataSeederBase<Group>
    {
        protected override void Initialize()
        {
            base.Initialize();
            Objects = new List<Group>
            {
                new Group { Id = Guid.NewGuid(), Name = "Girard High School Staff", Description = "Staff members of Girard High School", DateCreated = DateTime.UtcNow }
            };
        }
    }
}
