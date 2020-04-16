using SchoolMachine.DataAccess.Entities.Models.Geolocation;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using SchoolMachine.DataAccess.Entities.SeedData.Model.Geolocation;
using SchoolMachine.DataAccess.Entities.SeedData.Model.SchoolData;
using System;
using System.Collections.Generic;

namespace SchoolMachine.DataAccess.Entities.SeedData
{
    public static class DataSeeder
    {
        #region Seeders

        // NOTE: The order these seeders is created can be important because of foreign key relationships
        public static CountrySeeder CountrySeeder { get; set; } = new CountrySeeder();
        public static StateSeeder StateSeeder { get; set; } = new StateSeeder();
        public static DistrictSeeder DistrictSeeder { get; set; } = new DistrictSeeder();
        public static SchoolSeeder SchoolSeeder { get; set; } = new SchoolSeeder();
        public static StudentSeeder StudentSeeder { get; set; } = new StudentSeeder();

        #endregion Seeders

        #region Operations

        public static void Seed(SchoolMachineContext context)
        {
            // ToDo: Perform seeding of records that require first level master tables here
        }

        #endregion Operations

        #region Locations

        public static List<Location> Locations = new List<Location>
        {
            new Location { Id = Guid.NewGuid(), Description = "GHS Main Entrance", Street1 = "1244", Street2 = "Shannon Rd.", City = "Girard", State = "OH", PostalCode = "44420", Country = "USA", Latitude = 41.171231, Longitude = -80.691469 }
        };

        #endregion Locations

        #region DistrictSchools

        public static List<DistrictSchool> DistrictSchools = new List<DistrictSchool>
        {
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Austintown Local School District"].Id, SchoolId = SchoolSeeder.Dictionary["Austintown Fitch High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Bloomfield-Mespo Local School District"].Id, SchoolId = SchoolSeeder.Dictionary["Bloomfield Middle/High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Bloomfield-Mespo Local School District"].Id, SchoolId = SchoolSeeder.Dictionary["Mesopatamia Elementary"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Bristol Local School District"].Id, SchoolId = SchoolSeeder.Dictionary["Bristol Elementary"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Bristol Local School District"].Id, SchoolId = SchoolSeeder.Dictionary["Bristol Middle & High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Brookfield Local School District"].Id, SchoolId = SchoolSeeder.Dictionary["Brookfield Elementary School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Brookfield Local School District"].Id, SchoolId = SchoolSeeder.Dictionary["Brookfield Middle School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Brookfield Local School District"].Id, SchoolId = SchoolSeeder.Dictionary["Brookfield High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Brookfield Local School District"].Id, SchoolId = SchoolSeeder.Dictionary["Trumbull Career & Technical Center"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Champion Local School District"].Id, SchoolId = SchoolSeeder.Dictionary["Central Elementary"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Champion Local School District"].Id, SchoolId = SchoolSeeder.Dictionary["Champion High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Champion Local School District"].Id, SchoolId = SchoolSeeder.Dictionary["Champion Middle School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Girard City School District"].Id, SchoolId = SchoolSeeder.Dictionary["Girard High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Girard City School District"].Id, SchoolId = SchoolSeeder.Dictionary["Girard Intermediate"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Girard City School District"].Id, SchoolId = SchoolSeeder.Dictionary["Girard Junior High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Girard City School District"].Id, SchoolId = SchoolSeeder.Dictionary["Prospect Elementary"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Girard City School District"].Id, SchoolId = SchoolSeeder.Dictionary["Trumbull Career & Technical Center"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Howland Local School District"].Id, SchoolId = SchoolSeeder.Dictionary["Glen Primary School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Howland Local School District"].Id, SchoolId = SchoolSeeder.Dictionary["H.C. Mines Elementary"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Howland Local School District"].Id, SchoolId = SchoolSeeder.Dictionary["North Road Intermediate"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Howland Local School District"].Id, SchoolId = SchoolSeeder.Dictionary["Howland High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Howland Local School District"].Id, SchoolId = SchoolSeeder.Dictionary["Howland Middle School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Howland Local School District"].Id, SchoolId = SchoolSeeder.Dictionary["Springs Primary School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Hubbard Exempted Village School District"].Id, SchoolId = SchoolSeeder.Dictionary["Hubbard Elementary School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Hubbard Exempted Village School District"].Id, SchoolId = SchoolSeeder.Dictionary["Hubbard High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictSeeder.Dictionary["Hubbard Exempted Village School District"].Id, SchoolId = SchoolSeeder.Dictionary["Hubbard Middle School"].Id, StartDate = DateTime.UtcNow }
        };

        #endregion DistrictSchools

        #region SchoolStudents

        public static List<SchoolStudent> SchoolStudents = new List<SchoolStudent>
        {
            new SchoolStudent
            {
                DateCreated = DateTime.UtcNow,
                GradeLevel = "9",
                Id = Guid.NewGuid(),
                RegistrationDate = DateTime.UtcNow,
                SchoolId = DataSeeder.SchoolSeeder.Dictionary["Austintown Fitch High School"].Id,
                StudentId = DataSeeder.StudentSeeder.Objects[0].Id
            },
            new SchoolStudent
            {
                DateCreated = DateTime.UtcNow,
                GradeLevel = "9",
                Id = Guid.NewGuid(),
                RegistrationDate = DateTime.UtcNow,
                SchoolId = DataSeeder.SchoolSeeder.Dictionary["Bloomfield Middle/High School"].Id,
                StudentId = DataSeeder.StudentSeeder.Objects[1].Id
            },
            new SchoolStudent
            {
                DateCreated = DateTime.UtcNow,
                GradeLevel = "9",
                Id = Guid.NewGuid(),
                RegistrationDate = DateTime.UtcNow,
                SchoolId = DataSeeder.SchoolSeeder.Dictionary["Bloomfield Middle/High School"].Id,
                StudentId = DataSeeder.StudentSeeder.Objects[2].Id
            },
            new SchoolStudent
            {
                DateCreated = DateTime.UtcNow,
                GradeLevel = "9",
                Id = Guid.NewGuid(),
                RegistrationDate = DateTime.UtcNow,
                SchoolId = DataSeeder.SchoolSeeder.Dictionary["Girard High School"].Id,
                StudentId = DataSeeder.StudentSeeder.Objects[3].Id
            },
            new SchoolStudent
            {
                DateCreated = DateTime.UtcNow,
                GradeLevel = "9",
                Id = Guid.NewGuid(),
                RegistrationDate = DateTime.UtcNow,
                SchoolId = DataSeeder.SchoolSeeder.Dictionary["Girard High School"].Id,
                StudentId = DataSeeder.StudentSeeder.Objects[4].Id
            },
            new SchoolStudent
            {
                DateCreated = DateTime.UtcNow,
                GradeLevel = "9",
                Id = Guid.NewGuid(),
                RegistrationDate = DateTime.UtcNow,
                SchoolId = DataSeeder.SchoolSeeder.Dictionary["Girard High School"].Id,
                StudentId = DataSeeder.StudentSeeder.Objects[5].Id
            },
            new SchoolStudent
            {
                DateCreated = DateTime.UtcNow,
                GradeLevel = "9",
                Id = Guid.NewGuid(),
                RegistrationDate = DateTime.UtcNow,
                SchoolId = DataSeeder.SchoolSeeder.Dictionary["Girard High School"].Id,
                StudentId = DataSeeder.StudentSeeder.Objects[6].Id
            }
        };

        #endregion SchoolStudents
    }
}
