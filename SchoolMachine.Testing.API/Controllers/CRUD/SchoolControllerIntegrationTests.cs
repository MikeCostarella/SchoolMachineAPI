using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using SchoolMachine.DataAccess.Entities.SeedData;
using SchoolMachine.Testing.API.Base;

namespace SchoolMachine.Testing.API.Controllers.CRUD
{

    /// <summary>
    /// Performs integration tests on SchoolController action methods
    /// </summary>
    [TestClass]
    public class SchoolControllerIntegrationTests : SchoolMachineApiIntegrationTestBase
    {
        // ToDo: Fill in the test logic
        #region Action Tests

        [TestMethod]
        public void GetAllSchools()
        {
            Test_GetAllObjects<School>("api/school/", DataSeeder.SchoolSeeder.Objects);
        }

        [TestMethod]
        public void GetSchoolById()
        {
            Test_GetNamedEntityById<School>("api/school/");
        }

        [TestMethod]
        public void CreateSchool()
        {

        }

        [TestMethod]
        public void UpdateSchool()
        {

        }

        [TestMethod]
        public void DeleteSchool()
        {

        }

        #endregion Action Tests
    }
}
