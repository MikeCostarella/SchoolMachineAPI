using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolMachine.DataAccess.Entities.SeedData;
using SchoolMachine.Repository.Entities;
using SchoolMachine.Repository.Test.Base;
using System.Linq;

namespace SchoolMachine.Repository.Test
{
    [TestClass]
    public class SchoolStudentRepositoryIntegrationTests : BaseRepositoryIntegrationTests
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
        public void StudentsBySchool()
        {
            // Setup
            var schoolStudentRepository = new SchoolStudentRepository(SchoolMachineContext);
            var schoolRepository = new SchoolRepository(SchoolMachineContext);
            var seededSchool = DataSeeder.SchoolSeeder.Objects.FirstOrDefault();
            Assert.IsTrue(seededSchool != null, "No schools were setup in the data seeder.");
            var seededSchoolStudents = DataSeeder.SchoolStudents.Where(s => s.SchoolId == seededSchool.Id);
            var school = schoolRepository.GetAllSchools().Result.FirstOrDefault();
            Assert.IsTrue(school != null, "No schools were saved to the database by the data seeder.");
            // Test Logic
            var students = schoolStudentRepository.StudentsBySchool(school.Id).Result;
            // Assertions
            Assert.IsTrue(students.Count() >= seededSchoolStudents.Count(), string.Format("DataSeeder has {0} SchoolStudents and only found {1}", seededSchoolStudents.Count(), students.Count()));
        }

        #endregion Tests
    }
}
