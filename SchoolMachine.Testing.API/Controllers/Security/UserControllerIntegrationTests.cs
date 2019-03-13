using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SchoolMachine.API.Dtos;
using SchoolMachine.DataAccess.Entities.SeedData;
using SchoolMachine.Testing.API.Base;
using System;
using System.Collections.Generic;

namespace SchoolMachine.Testing.API.Controllers.Security
{
    /// <summary>
    /// Performs integration tests on UserController action methods
    /// </summary>
    [TestClass]
    public class UserControllerIntegrationTests : SchoolMachineApiIntegrationTestBase
    {
        #region Test Action Tests

        [TestMethod]
        public void Authenticate()
        {

        }

        [TestMethod]
        public void Register()
        {

        }

        [TestMethod]
        public void GetAll()
        {
            try
            {
                // Act
                var response = Client.GetAsync("api/user/").Result;
                // Assert
                response.EnsureSuccessStatusCode();
                var jsonString = response.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<UserDto>>(jsonString);
                var expectedList = DataSeeder.UserSeeder.Objects;
                Assert.IsTrue(list.Count >= expectedList.Count, string.Format("{0} objects were returned from the service call but {1} objects were seeded", list.Count, expectedList.Count));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GetById()
        {

        }

        [TestMethod]
        public void Update()
        {

        }

        [TestMethod]
        public void Delete()
        {

        }

        #endregion Action Tests
    }
}
