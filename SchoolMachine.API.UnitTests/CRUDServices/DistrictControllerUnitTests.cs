using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SchoolMachine.API.Controllers.CRUD;
using SchoolMachine.API.Models;
using SchoolMachine.API.UnitTests.Base;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using SchoolMachine.DataAccess.Entities.SeedData.Model.SchoolData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolMachine.API.UnitTests.CRUDServices
{
    /// <summary>
    /// Performs unit tests.
    /// ToDo: Add more tests for edge and exception cases
    /// </summary>
    [TestClass]
    public class DistrictControllerUnitTests : BaseControllerUnitTests
    {

        private DistrictSeeder _districtSeeder = new DistrictSeeder();

        [TestMethod]
        public void GetAllDistricts()
        {
            // Arrange
            Mock.Get(_repositoryWrapper.District).Setup(x => x.GetAllDistricts()).ReturnsAsync(_districtSeeder.Objects);
            var controller = new DistrictController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.GetAllDistricts().Result;
            // Assert 
            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            var districts = okObjectResult.Value as IEnumerable<District>;
            Assert.IsTrue(districts.Count() >= _districtSeeder.Objects.Count(), string.Format("Found {0} District(s) but {1} were seeded", districts.Count(), _districtSeeder.Objects.Count()));
        }

        [TestMethod]
        public void GetDistrictById()
        {
            // Arrange
            var district = _districtSeeder.Objects.FirstOrDefault();
            Assert.IsNotNull(district, string.Format("No districts were setup in the DataSeeder"));
            Mock.Get(_repositoryWrapper.District).Setup(x => x.GetDistrictById(district.Id)).ReturnsAsync(district);
            var controller = new DistrictController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.GetDistrictById(district.Id).Result;
            // Assert 
            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            var resultList = okObjectResult.Value as District;
            Assert.IsTrue(resultList.Id == district.Id);
        }

        [TestMethod]
        public void CreateDistrict()
        {
            // Arrange
            var districtDto = new DistrictDto
            {
                Name = "New District 1"
            };
            var district = _mapper.Map<District>(districtDto);
            Mock.Get(_repositoryWrapper.District).Setup(x => x.CreateDistrict(district));
            Mock.Get(_repositoryWrapper.District).Setup(x => x.GetDistrictById(district.Id)).ReturnsAsync(district);
            var controller = new DistrictController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.CreateDistrict(districtDto).Result;
            // Assert 
            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
        }

        [TestMethod]
        public void UpdateDistrict()
        {
            // Arrange
            var districtDto = new DistrictDto
            {
                Name = "Update District 1"
            };
            var district = _mapper.Map<District>(districtDto);
            district.Id = Guid.NewGuid();
            Mock.Get(_repositoryWrapper.District).Setup(x => x.UpdateDistrict(district, district));
            Mock.Get(_repositoryWrapper.District).Setup(x => x.GetDistrictById(district.Id)).ReturnsAsync(district);
            var controller = new DistrictController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.UpdateDistrict(district.Id, districtDto).Result;
            // Assert 
            var noContentResult = actionResult as NoContentResult;
            Assert.IsNotNull(noContentResult);
        }

        // ToDo: Figure out why the mock setup for DistrictRepository.DeleteDistrict() is not being mocked correctly 
        //[TestMethod]
        public void DeleteDistrict()
        {
            // Arrange
            var district = _districtSeeder.Objects[0];
            Mock.Get(_repositoryWrapper.District).Setup(x => x.DeleteDistrict(district));
            Mock.Get(_repositoryWrapper.District).Setup(x => x.GetDistrictById(district.Id)).ReturnsAsync(district);
            Mock.Get(_repositoryWrapper.DistrictSchool).Setup(x => x.DistrictSchoolsByDistrict(district.Id)).ReturnsAsync(new List<DistrictSchool>());
            var controller = new DistrictController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.DeleteDistrict(district.Id).Result;
            // Assert 
            var noContentResult = actionResult as NoContentResult;
            Assert.IsNotNull(noContentResult);
        }
    }
}
