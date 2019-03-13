using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SchoolMachine.API.Dtos;
using SchoolMachine.API.Extensions;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using SchoolMachine.DataAccess.Entities.SeedData;
using SchoolMachine.Testing.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace SchoolMachine.Testing.API.Controllers.CRUD
{
    /// <summary>
    /// Performs integration tests on DistrictController action methods
    /// </summary>
    [TestClass]
    public class DistrictControllerIntegrationTests : SchoolMachineApiIntegrationTestBase
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
        public void GetDistrictById()
        {
            // Assert
            var response1 = Client.GetAsync("api/district/").Result;
            var districts = JsonConvert.DeserializeObject<List<District>>(response1.Content.ReadAsStringAsync().Result);
            var district = districts.FirstOrDefault();
            Assert.IsNotNull(district, "No Districts returned from setup service call.");
            // Act
            var response = Client.GetAsync("api/district/" + district.Id.ToString()).Result;
            // Assert
            response.EnsureSuccessStatusCode();
            var jsonString = response.Content.ReadAsStringAsync().Result;
            var testObject = JsonConvert.DeserializeObject<District>(jsonString);
            Assert.IsNotNull(testObject, "Returned test object was null");
            Assert.IsTrue(testObject.Name == district.Name, string.Format("Test object name {0} is not eqaul to expected object name {1}", testObject.Name, district.Name));
        }

        [TestMethod]
        public void CreateDistrict()
        {
            var districtDto = new DistrictDto
            {
                Name = "Test District 1"
            };
            try
            {
                var httpResponseMessage = Client.PostObjectAsync("api/district/CreateDistrict", districtDto);
                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void UpdateDistrict()
        {
            // api/district/UpdateDistrict?id=f2f794c7-3ac2-4608-a2f3-c5fc53aeec18
            // Assert
            var response1 = Client.GetAsync("api/district/").Result;
            var districts = JsonConvert.DeserializeObject<List<District>>(response1.Content.ReadAsStringAsync().Result);
            var district = districts.FirstOrDefault();
            Assert.IsNotNull(district, "No Districts returned from setup service call.");
            var districtDto = new DistrictDto
            {
                Name = "Test District 1"
            };
            // Act
            try
            {
                var httpResponseMessage = Client.PutObjectAsync("api/district/UpdateDistrict?id=" + district.Id.ToString(), districtDto);
                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void DeleteDistrict()
        {

        }

        #endregion Action Tests
    }
}
