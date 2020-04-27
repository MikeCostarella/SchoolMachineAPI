using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolMachine.API.Extensions;
using SchoolMachine.API.Models;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using SchoolMachine.DataAccess.Entities.SeedData;
using SchoolMachine.Testing.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolMachine.Testing.API.Controllers.CRUD
{
    /// <summary>
    /// Performs integration tests on DistrictController action methods
    /// </summary>
    [TestClass]
    public class DistrictControllerIntegrationTests : SchoolMachineApiIntegrationTestBase
    {
        #region Action Tests

        [TestMethod]
        public void GetAllDistricts()
        {
            Test_GetAllObjects<District>("api/district/", DataSeeder.DistrictSeeder.Objects);
        }

        [TestMethod]
        public void GetDistrictById()
        {
            Test_GetNamedEntityById<District>("api/district/");
        }

        [TestMethod]
        public void CreateDistrict()
        {
            // Arrange
            var districtDto = new DistrictDto
            {
                Name = "Test District 1"
            };
            try
            {
                // Act
                var httpResponseMessage = Client.PostObjectAsync("api/district/CreateDistrict", districtDto);
                // Assert
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
            // Arrange
            var dto = new DistrictDto
            {
                Name = "Test District 1"
            };
            var arrangementObject = ((List<District>)Client.GetObjectAsync<List<District>>("api/district/")).FirstOrDefault();
            Assert.IsNotNull(arrangementObject, "No arrangementObject(s) returned from setup service call.");
            // Act
            try
            {
                var httpResponseMessage = Client.PutObjectAsync("api/district/UpdateDistrict?id=" + arrangementObject.Id.ToString(), dto);
                // Assert
                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void DeleteFailsWhenChildObjectsArePresent()
        {
            // ToDo: Set up a repository search for a district with children
            //// Arrange
            //var testObject = ((List<District>)Client.GetObjectAsync<List<District>>("api/district/")).FirstOrDefault();
            //Assert.IsNotNull(testObject, "No Districts returned from setup service call.");
            //var childObjects = ((List<DistrictSchool>)Client.GetObjectAsync<List<DistrictSchool>>("api/districtschool?schoolId=" + testObject.Id.ToString()));
            //// Act
            //var response = Client.DeleteAsync("api/district/" + testObject.Id.ToString()).Result;
            //// Assert
            //response.EnsureSuccessStatusCode();
        }

        [TestMethod]
        public void DeleteDistrict()
        {
            // ToDo: Set up a repository search for a district without children
        }

        #endregion Action Tests
    }
}
