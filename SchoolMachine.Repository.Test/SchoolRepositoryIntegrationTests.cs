using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.DataAccess.Entities.Extensions;
using SchoolMachine.DataAccess.Entities.SchoolData.Models;
using SchoolMachine.DataAccess.Entities.SeedData;
using SchoolMachine.Repository.Entities;
using System.Linq;

namespace SchoolMachine.Repository.Test
{
    [TestClass]
    public class SchoolRepositoryIntegrationTest
    {
        public static SchoolMachineContext SchoolMachineContext { get; set; }

        #region Setup/Teardown

        [ClassInitialize]
        public static void TestClassSetup(TestContext context)
        {
            // Setup
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddEntityFrameworkNpgsql()
                .AddDbContext<SchoolMachineContext>()
                .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<SchoolMachineContext>();
            // ToDo: factor this to somewhere less visible
            builder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=SchoolMachine;User Id=postgres;Password=password;");
            var dbContextOptions = builder.Options;
            SchoolMachineContext = new SchoolMachineContext(dbContextOptions);
            SchoolMachineContext.Database.Migrate();

            // Test Assertions
            Assert.IsTrue(SchoolMachineContext.Roles.Count() == DataSeeder.Roles.Count()
                , string.Format("Database has {0} Roles and Seeder has {1}", SchoolMachineContext.Roles.Count(), DataSeeder.Roles.Count()));
            Assert.IsTrue(SchoolMachineContext.Schools.Count() == DataSeeder.Schools.Count()
                , string.Format("Database has {0} Schools and Seeder has {1}", SchoolMachineContext.Schools.Count(), DataSeeder.Schools.Count()));
            Assert.IsTrue(SchoolMachineContext.Students.Count() == DataSeeder.Students.Count()
                , string.Format("Database has {0} Students and Seeder has {1}", SchoolMachineContext.Students.Count(), DataSeeder.Students.Count()));
            Assert.IsTrue(SchoolMachineContext.Users.Count() == DataSeeder.Users.Count()
                , string.Format("Database has {0} Users and Seeder has {1}", SchoolMachineContext.Users.Count(), DataSeeder.Users.Count()));
        }

        [ClassCleanup]
        public static void TestClassCleanup()
        {
            SchoolMachineContext = null;
        }

        #endregion Setup/Teardown

        #region Test Methods

        [TestMethod]
        public void GetAllSchools()
        {
            // Setup
            var schoolRepository = new SchoolRepository(SchoolMachineContext);
            // Test Logic
            var schools = schoolRepository.GetAllSchools();
            // Assertions
            Assert.IsTrue(schools.Count() >= DataSeeder.Schools.Count()
                , string.Format("Database has {0} Schools and Seeder has {1}", schools.Count(), DataSeeder.Schools.Count()));
        }

        [TestMethod]
        public void GetSchoolById()
        {
            // Setup
            var schoolRepository = new SchoolRepository(SchoolMachineContext);
            // Test Logic
            var school = schoolRepository.GetSchoolById(DataSeeder.Schools[0].Id);
            // Assertions
            Assert.IsNotNull(school, string.Format("Did not find school with Id: {0}", DataSeeder.Schools[0].Id));
        }

        // ToDo: getting the school details from repository needs some more work yet
        [TestMethod]
        public void GetSchoolWithDetails()
        {
            // Setup
            var schoolRepository = new SchoolRepository(SchoolMachineContext);
            // Test Logic
            var school = schoolRepository.GetSchoolWithDetails(DataSeeder.Schools[0].Id);
            // Assertions
            Assert.IsNotNull(school, string.Format("Did not find school with Id: {0}", DataSeeder.Schools[0].Id));
        }

        [TestMethod]
        public void CreateSchool()
        {
            // Setup
            var schoolRepository = new SchoolRepository(SchoolMachineContext);
            var newSchool = new School {
                Name = "Test School 1"
            };
            // Test Logic
            schoolRepository.CreateSchool(newSchool);
            // Assertions
            var savedSchool = schoolRepository.GetSchoolById(newSchool.Id);
            Assert.IsNotNull(savedSchool, string.Format("School {0} was not saved in the database", newSchool.Id));
            Assert.IsTrue(savedSchool.Name == newSchool.Name, string.Format("School({0}).Name was not saved in the database", newSchool.Id));
            // Teardown
            schoolRepository.DeleteSchool(savedSchool);
            var shouldBeDeletedSchool = schoolRepository.GetSchoolById(newSchool.Id);
            Assert.IsTrue(shouldBeDeletedSchool.IsEmptyObject(), string.Format("School({0}) was not deleted from the database", newSchool.Id));
        }

        [TestMethod]
        public void UpdateSchool()
        {
            // Setup
            var schoolRepository = new SchoolRepository(SchoolMachineContext);
            var newSchool = new School
            {
                Name = "Test School 2"
            };
            schoolRepository.CreateSchool(newSchool);
            var savedSchool = schoolRepository.GetSchoolById(newSchool.Id);
            Assert.IsNotNull(savedSchool, string.Format("School {0} was not saved in the database", newSchool.Id));
            Assert.IsTrue(savedSchool.Name == newSchool.Name, string.Format("School({0}).Name was not saved in the database", newSchool.Id));

            // Test Logic
            newSchool.Name = "Test School 2 - Modified";
            schoolRepository.UpdateSchool(savedSchool, newSchool);

            // Assertions
            var retrievedSchool = schoolRepository.GetSchoolById(savedSchool.Id);
            Assert.IsFalse(retrievedSchool.IsEmptyObject(), string.Format("Updated school({0}) was not retrieved from the database", newSchool.Id));
            Assert.IsTrue(retrievedSchool.Name == newSchool.Name, string.Format("School({0}).Name was not updated in the database", newSchool.Id));

            // Teardown
            schoolRepository.DeleteSchool(savedSchool);
            var shouldBeDeletedSchool = schoolRepository.GetSchoolById(newSchool.Id);
            Assert.IsTrue(shouldBeDeletedSchool.IsEmptyObject(), string.Format("School({0}) was not deleted from the database", newSchool.Id));
        }

        [TestMethod]
        public void DeleteSchool()
        {
            // Setup
            var schoolRepository = new SchoolRepository(SchoolMachineContext);
            var newSchool = new School
            {
                Name = "Test School 3"
            };
            schoolRepository.CreateSchool(newSchool);
            var savedSchool = schoolRepository.GetSchoolById(newSchool.Id);
            Assert.IsNotNull(savedSchool, string.Format("School {0} was not saved in the database", newSchool.Id));
            Assert.IsTrue(savedSchool.Name == newSchool.Name, string.Format("School({0}).Name was not saved in the database", newSchool.Id));
            // Test Logic
            schoolRepository.DeleteSchool(savedSchool);
            // Assertions
            var shouldBeDeletedSchool = schoolRepository.GetSchoolById(newSchool.Id);
            Assert.IsTrue(shouldBeDeletedSchool.IsEmptyObject(), string.Format("School({0}) was not deleted from the database", newSchool.Id));
        }

        #endregion Test Methods
    }
}