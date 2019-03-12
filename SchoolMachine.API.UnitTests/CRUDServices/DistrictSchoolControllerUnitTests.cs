using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SchoolMachine.API.Controllers.CRUD;
using SchoolMachine.API.Dtos;
using SchoolMachine.API.UnitTests.Base;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using SchoolMachine.DataAccess.Entities.SeedData;
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
    public class DistrictSchoolControllerUnitTests : BaseControllerUnitTests
    {

        private DistrictSeeder _districtSeeder = new DistrictSeeder();

        [TestMethod]
        public void GetAllDistrictSchools()
        {
            // Arrange
            Mock.Get(_repositoryWrapper.DistrictSchool).Setup(x => x.GetAllDistrictSchools()).ReturnsAsync(DataSeeder.DistrictSchools);
            var controller = new DistrictSchoolController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.GetAllDistrictSchools().Result;
            // Assert 
            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            var resultList = okObjectResult.Value as IEnumerable<DistrictSchool>;
            Assert.IsTrue(resultList.Count() == DataSeeder.DistrictSchools.Count());
        }

        [TestMethod]
        public void GetDistrictSchoolById()
        {
            // Arrange
            var districtSchool = DataSeeder.DistrictSchools.FirstOrDefault();
            Assert.IsNotNull(districtSchool, string.Format("No DistrictSchool(s) were setup in the DataSeeder"));
            Mock.Get(_repositoryWrapper.DistrictSchool).Setup(x => x.GetDistrictSchoolById(districtSchool.Id)).ReturnsAsync(districtSchool);
            var controller = new DistrictSchoolController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.GetDistrictSchoolById(districtSchool.Id).Result;
            // Assert 
            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            var resultList = okObjectResult.Value as DistrictSchool;
            Assert.IsTrue(resultList.Id == districtSchool.Id);
        }

        [TestMethod]
        public void CreateDistrictSchool()
        {
            // Arrange
            var districtSchoolDto = new DistrictSchoolDto
            {
                EndDate = DateTime.UtcNow,
                StartDate = DateTime.UtcNow,
                SchoolId = DataSeeder.SchoolSeeder.Objects[0].Id,
                DistrictId = _districtSeeder.Objects[0].Id
            };
            var districtSchool = _mapper.Map<DistrictSchool>(districtSchoolDto);
            Mock.Get(_repositoryWrapper.DistrictSchool).Setup(x => x.CreateDistrictSchool(districtSchool));
            Mock.Get(_repositoryWrapper.DistrictSchool).Setup(x => x.GetDistrictSchoolById(districtSchool.Id)).ReturnsAsync(districtSchool);
            var controller = new DistrictSchoolController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.CreateDistrictSchool(districtSchoolDto).Result;
            // Assert 
            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
        }

        [TestMethod]
        public void UpdateDistrictSchool()
        {
            // Arrange
            var schoolStudentDto = new DistrictSchoolDto
            {
                EndDate = DateTime.UtcNow,
                StartDate = DateTime.UtcNow,
                SchoolId = DataSeeder.SchoolSeeder.Objects[0].Id,
                DistrictId = _districtSeeder.Objects[0].Id
            };
            var schoolStudent = _mapper.Map<DistrictSchool>(schoolStudentDto);
            Mock.Get(_repositoryWrapper.DistrictSchool).Setup(x => x.UpdateDistrictSchool(schoolStudent, schoolStudent));
            Mock.Get(_repositoryWrapper.DistrictSchool).Setup(x => x.GetDistrictSchoolById(schoolStudent.Id)).ReturnsAsync(schoolStudent);
            var controller = new DistrictSchoolController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.UpdateDistrictSchool(schoolStudent.Id, schoolStudentDto).Result;
            // Assert 
            var noContentResult = actionResult as NoContentResult;
            Assert.IsNotNull(noContentResult);
        }

        // ToDo: Figure out why the mock setup for DistrictSchoolRepository.DeleteDistrictSchool() is not being mocked correctly 
        //[TestMethod]
        public void DeleteDistrictSchool()
        {
            // Arrange
            var districtSchool = DataSeeder.DistrictSchools[0];
            Mock.Get(_repositoryWrapper.DistrictSchool).Setup(x => x.DeleteDistrictSchool(districtSchool));
            Mock.Get(_repositoryWrapper.DistrictSchool).Setup(x => x.GetDistrictSchoolById(districtSchool.Id)).ReturnsAsync(districtSchool);
            var controller = new DistrictSchoolController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.DeleteDistrictSchool(districtSchool.Id).Result;
            // Assert
            var noContentResult = actionResult as NoContentResult;
            Assert.IsNotNull(noContentResult);
        }
    }
}
