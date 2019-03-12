using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using SchoolMachine.DataAccess.Entities.SeedData.Base;
using System;
using System.Collections.Generic;

namespace SchoolMachine.DataAccess.Entities.SeedData.Model.SchoolData
{
    public class SchoolSeeder : DataSeederBase<School>
    {
        protected override void Initialize()
        {
            base.Initialize();
            Objects = new List<School>
            {
                new School { Id = Guid.NewGuid(), Name = "Austintown Fitch High School" },
                new School { Id = Guid.NewGuid(), Name = "Badger Elementary School" },
                new School { Id = Guid.NewGuid(), Name = "Badger Middle School" },
                new School { Id = Guid.NewGuid(), Name = "Badger High School" },
                new School { Id = Guid.NewGuid(), Name = "Bloomfield Middle/High School" },
                new School { Id = Guid.NewGuid(), Name = "Bristol Elementary" },
                new School { Id = Guid.NewGuid(), Name = "Bristol Middle & High School" },
                new School { Id = Guid.NewGuid(), Name = "Brookfield Elementary School" },
                new School { Id = Guid.NewGuid(), Name = "Brookfield Middle School" },
                new School { Id = Guid.NewGuid(), Name = "Brookfield High School" },
                new School { Id = Guid.NewGuid(), Name = "Canfield High School" },
                new School { Id = Guid.NewGuid(), Name = "Central Elementary" }, // Champion Local School District
                new School { Id = Guid.NewGuid(), Name = "Champion High School" },
                new School { Id = Guid.NewGuid(), Name = "Champion Middle School" },
                new School { Id = Guid.NewGuid(), Name = "Girard High School" },
                new School { Id = Guid.NewGuid(), Name = "Girard Intermediate" },
                new School { Id = Guid.NewGuid(), Name = "Girard Junior High School" },
                new School { Id = Guid.NewGuid(), Name = "Glen Primary School" }, // Howland Local School District
                new School { Id = Guid.NewGuid(), Name = "H.C. Mines Elementary" }, // Howland Local School District
                new School { Id = Guid.NewGuid(), Name = "Hubbard Elementary School" },
                new School { Id = Guid.NewGuid(), Name = "Hubbard High School" },
                new School { Id = Guid.NewGuid(), Name = "Hubbard Middle School" },
                new School { Id = Guid.NewGuid(), Name = "Howland High School" },
                new School { Id = Guid.NewGuid(), Name = "Howland Middle School" },
                new School { Id = Guid.NewGuid(), Name = "Liberty High School" },
                new School { Id = Guid.NewGuid(), Name = "Mesopatamia Elementary" }, // Bloomfield-Mespo Local School District
                new School { Id = Guid.NewGuid(), Name = "North Road Intermediate" }, // Howland Local School District
                new School { Id = Guid.NewGuid(), Name = "Prospect Elementary" }, // Girard City School District
                new School { Id = Guid.NewGuid(), Name = "Springs Primary School" }, // Howland Local School District
                new School { Id = Guid.NewGuid(), Name = "Trumbull Career & Technical Center" } // Multi-School District Owned
            };
        }
    }
}
