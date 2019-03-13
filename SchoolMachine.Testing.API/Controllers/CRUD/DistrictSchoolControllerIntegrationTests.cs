using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using SchoolMachine.DataAccess.Entities.SeedData;
using SchoolMachine.Testing.API.Base;
using System;
using System.Collections.Generic;

namespace SchoolMachine.Testing.API.Controllers.CRUD
{
    /// <summary>
    /// Performs integration tests on DistrictController action methods
    /// </summary>
    [TestClass]
    public class DistrictSchoolControllerIntegrationTests : SchoolMachineApiIntegrationTestBase
    {

        // ToDo: Fill in the test logic
        #region Action Tests

        [TestMethod]
        public void GetAllDistrictSchools()
        {
            try
            {
                // Act
                var response = Client.GetAsync("api/districtschool/").Result;
                // Assert
                response.EnsureSuccessStatusCode();
                var jsonString = response.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<DistrictSchool>>(jsonString);
                var expectedList = DataSeeder.DistrictSchools;
                Assert.IsTrue(list.Count >= expectedList.Count, string.Format("{0} objects were returned from the service call but {1} objects were seeded", list.Count, expectedList.Count));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GetDistrictSchoolById()
        {

        }

        [TestMethod]
        public void GetDistrictSchoolsBySchoolId()
        {

        }

        [TestMethod]
        public void GetDistrictSchoolsByDistrictId()
        {

        }

        [TestMethod]
        public void CreateDistrictSchool()
        {

        }

        [TestMethod]
        public void UpdateDistrictSchool()
        {

        }

        [TestMethod]
        public void DeleteDistrictSchool()
        {

        }

        #endregion Action Tests
    }
}
