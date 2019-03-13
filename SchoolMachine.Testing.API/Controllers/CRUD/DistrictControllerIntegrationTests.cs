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
    public class DistrictControllerIntegrationTests : SchoolMachineAPIIntegrationTestBase
    {
        // ToDo: Fill in the test logic
        #region Action Tests

        [TestMethod]
        public void GetAllDistricts()
        {
            try
            {
                // Act
                var response = Client.GetAsync("api/district/").Result;
                // Assert
                response.EnsureSuccessStatusCode();
                var jsonString = response.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<District>>(jsonString);
                var expectedList = DataSeeder.DistrictSeeder.Objects;
                Assert.IsTrue(list.Count >= expectedList.Count, string.Format("{0} objects were returned from the service call but {1} objects were seeded", list.Count, expectedList.Count));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
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
