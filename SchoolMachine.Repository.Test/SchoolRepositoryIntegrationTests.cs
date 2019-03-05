using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolMachine.DataAccess.Entities.Extensions;
using SchoolMachine.DataAccess.Entities.SchoolData.Models;
using SchoolMachine.DataAccess.Entities.SeedData;
using SchoolMachine.Repository.Entities;
using SchoolMachine.Repository.Test.Base;
using System.Linq;

namespace SchoolMachine.Repository.Test
{
    [TestClass]
    public class SchoolRepositoryIntegrationTest : BaseRepositoryIntegrationTests
    {
        #region Setup/Teardown

        [ClassInitialize]
        public static void TestClassSetup(TestContext context)
        {
            BaseTestClassSetup(context);
        }

        [ClassCleanup]
        public static void TestClassCleanup()
        {
            BaseTestClassCleanup();
        }

        #endregion Setup/Teardown

        #region Tests

        [TestMethod]
        public void GetAllSchools()
        {
            // Setup
            var schoolRepository = new SchoolRepository(SchoolMachineContext);
            // Test Logic
            var schools = schoolRepository.GetAllSchools().Result;
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

        [TestMethod]
        public void CreateSchool()
        {
            // Setup
            var schoolRepository = new SchoolRepository(SchoolMachineContext);
            var newSchool = new School {
                Name = "Test School 1"
            };
            // Test Logic
            schoolRepository.CreateSchool(newSchool).Wait();
            // Assertions
            var savedSchool = schoolRepository.GetSchoolById(newSchool.Id).Result;
            Assert.IsNotNull(savedSchool, string.Format("School {0} was not saved in the database", newSchool.Id));
            Assert.IsTrue(savedSchool.Name == newSchool.Name, string.Format("School({0}).Name was not saved in the database", newSchool.Id));
            // Teardown
            schoolRepository.DeleteSchool(savedSchool).Wait();
            var shouldBeDeletedSchool = schoolRepository.GetSchoolById(newSchool.Id).Result;
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
            schoolRepository.CreateSchool(newSchool).Wait();
            var savedSchool = schoolRepository.GetSchoolById(newSchool.Id).Result;
            Assert.IsNotNull(savedSchool, string.Format("School {0} was not saved in the database", newSchool.Id));
            Assert.IsTrue(savedSchool.Name == newSchool.Name, string.Format("School({0}).Name was not saved in the database", newSchool.Id));

            // Test Logic
            newSchool.Name = "Test School 2 - Modified";
            schoolRepository.UpdateSchool(savedSchool, newSchool).Wait();

            // Assertions
            var retrievedSchool = schoolRepository.GetSchoolById(savedSchool.Id).Result;
            Assert.IsFalse(retrievedSchool.IsEmptyObject(), string.Format("Updated school({0}) was not retrieved from the database", newSchool.Id));
            Assert.IsTrue(retrievedSchool.Name == newSchool.Name, string.Format("School({0}).Name was not updated in the database", newSchool.Id));

            // Teardown
            schoolRepository.DeleteSchool(savedSchool).Wait();
            var shouldBeDeletedSchool = schoolRepository.GetSchoolById(newSchool.Id).Result;
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
            schoolRepository.CreateSchool(newSchool).Wait();
            var savedSchool = schoolRepository.GetSchoolById(newSchool.Id).Result;
            Assert.IsNotNull(savedSchool, string.Format("School {0} was not saved in the database", newSchool.Id));
            Assert.IsTrue(savedSchool.Name == newSchool.Name, string.Format("School({0}).Name was not saved in the database", newSchool.Id));
            // Test Logic
            schoolRepository.DeleteSchool(savedSchool).Wait();
            // Assertions
            var shouldBeDeletedSchool = schoolRepository.GetSchoolById(newSchool.Id).Result;
            Assert.IsTrue(shouldBeDeletedSchool.IsEmptyObject(), string.Format("School({0}) was not deleted from the database", newSchool.Id));
        }

        #endregion Tests
    }
}