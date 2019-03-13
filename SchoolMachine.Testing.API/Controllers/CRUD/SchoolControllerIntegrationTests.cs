using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolMachine.Testing.API.Base;

namespace SchoolMachine.Testing.API.Controllers.CRUD
{

    /// <summary>
    /// Performs integration tests on SchoolController action methods
    /// </summary>
    [TestClass]
    public class SchoolControllerIntegrationTests : SchoolMachineAPIIntegrationTestBase
    {
        // ToDo: Fill in the test logic
        #region Action Tests

        [TestMethod]
        public void GetAllSchools()
        {
            var response = Client.GetAsync("api/schools/").Result;
            response.EnsureSuccessStatusCode();
        }

        [TestMethod]
        public void GetSchoolById()
        {
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
