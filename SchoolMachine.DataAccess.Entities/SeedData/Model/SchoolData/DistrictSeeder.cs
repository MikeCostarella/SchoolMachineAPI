using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using SchoolMachine.DataAccess.Entities.SeedData.Base;
using System;
using System.Collections.Generic;

namespace SchoolMachine.DataAccess.Entities.SeedData.Model.SchoolData
{
    public class DistrictSeeder : DataSeederBase<District>
    {
        protected override void  Initialize()
        {
            base.Initialize();
            Objects = new List<District>
            {
                new District { Id = Guid.NewGuid(), Name = "Austintown Local School District" },
                new District { Id = Guid.NewGuid(), Name = "Bloomfield-Mespo Local School District" },
                new District { Id = Guid.NewGuid(), Name = "Boardman Local School District" },
                new District { Id = Guid.NewGuid(), Name = "Bristol Local School District" },
                new District { Id = Guid.NewGuid(), Name = "Brookfield Local School District" },
                new District { Id = Guid.NewGuid(), Name = "Canfield Local School District" },
                new District { Id = Guid.NewGuid(), Name = "Champion Local School District" },
                new District { Id = Guid.NewGuid(), Name = "Girard City School District" },
                new District { Id = Guid.NewGuid(), Name = "Howland Local School District" },
                new District { Id = Guid.NewGuid(), Name = "Hubbard Exempted Village School District" },
                new District { Id = Guid.NewGuid(), Name = "Howland Local School District" },
                new District { Id = Guid.NewGuid(), Name = "Hubbard Exempted Village School District" },
                new District { Id = Guid.NewGuid(), Name = "Jackson-Milton Local School District" },
                new District { Id = Guid.NewGuid(), Name = "Joseph Badger Local School District" },
                new District { Id = Guid.NewGuid(), Name = "LaBrae Local School District" },
                new District { Id = Guid.NewGuid(), Name = "Lakeview Local School District" },
                new District { Id = Guid.NewGuid(), Name = "Liberty Local School District" },
                new District { Id = Guid.NewGuid(), Name = "Lordstown Local School District" },
                new District { Id = Guid.NewGuid(), Name = "Lowellville Local School District" },
                new District { Id = Guid.NewGuid(), Name = "Maplewood Local School District" },
                new District { Id = Guid.NewGuid(), Name = "Mathews Local School District" },
                new District { Id = Guid.NewGuid(), Name = "McDonald Local School District" },
                new District { Id = Guid.NewGuid(), Name = "Newton Falls Exempted Village School District" },
                new District { Id = Guid.NewGuid(), Name = "Niles City School District" },
                new District { Id = Guid.NewGuid(), Name = "Sebring Local School District" },
                new District { Id = Guid.NewGuid(), Name = "Southington Local School District" },
                new District { Id = Guid.NewGuid(), Name = "South Range Local School District" },
                new District { Id = Guid.NewGuid(), Name = "Springfield Local School District" },
                new District { Id = Guid.NewGuid(), Name = "Struthers City School District" },
                new District { Id = Guid.NewGuid(), Name = "Trumbull Career & Technical Center" },
                new District { Id = Guid.NewGuid(), Name = "Trumbull County Educational Service Center" },
                new District { Id = Guid.NewGuid(), Name = "Warren City School District" },
                new District { Id = Guid.NewGuid(), Name = "Weathersfield Local School District" },
                new District { Id = Guid.NewGuid(), Name = "West Branch Local School District" },
                new District { Id = Guid.NewGuid(), Name = "Western Reserve Local School District" },
                new District { Id = Guid.NewGuid(), Name = "Youngstown City School District" }
            };
        }
    }
}
