using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SchoolMachine.API.Controllers;
using SchoolMachine.API.Dtos;
using SchoolMachine.API.Helpers;
using SchoolMachine.API.UnitTests.Mocks;
using SchoolMachine.Contracts;
using SchoolMachine.Contracts.EntityRepositories;
using SchoolMachine.DataAccess.Entities.SchoolData.Models;
using SchoolMachine.DataAccess.Entities.SeedData;
using SchoolMachine.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolMachine.API.UnitTests
{
    [TestClass]
    public class SchoolControllerUnitTests
    {
        #region Private Variables

        private ILoggerManager _loggerManager = new MockLoggerManager();
        private IMapper _mapper;
        private MapperConfiguration _mapperConfiguration;
        private IRepositoryWrapper _repositoryWrapper;

        #endregion Private Variables

        [TestInitialize]
        public void TestInitialization()
        {
            _mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<AutoMapperProfile>(); });
            _mapper = _mapperConfiguration.CreateMapper();
            _mapper = new Mapper(_mapperConfiguration);
            _repositoryWrapper = Mock.Of<RepositoryWrapper>();
            _repositoryWrapper.School = Mock.Of<ISchoolRepository>();
            _repositoryWrapper.SchoolStudent = Mock.Of<ISchoolStudentRepository>();
        }

        [TestMethod]
        public void GetAllSchools()
        {
            // Arrange
            Mock.Get(_repositoryWrapper.School).Setup(x => x.GetAllSchools()).ReturnsAsync(DataSeeder.Schools);
            var controller = new SchoolController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.GetAllSchools().Result;
            // Assert 
            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            var reviews = okObjectResult.Value as IEnumerable<School>;
            Assert.IsTrue(reviews.Count() == DataSeeder.Schools.Count());
        }

        [TestMethod]
        public void GetSchoolById()
        {
            // Arrange
            var school = DataSeeder.Schools.FirstOrDefault();
            Assert.IsNotNull(school, string.Format("No schools were setup in the DataSeeder"));
            Mock.Get(_repositoryWrapper.School).Setup(x => x.GetSchoolById(school.Id)).ReturnsAsync(school);
            var controller = new SchoolController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.GetSchoolById(school.Id).Result;
            // Assert 
            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            var resutlSchool = okObjectResult.Value as School;
            Assert.IsTrue(resutlSchool.Id == school.Id);
        }

        [TestMethod]
        public void CreateSchool()
        {
            // Arrange
            var schoolDto = new SchoolDto
            {
                Name = "New School 1"
            };
            var school = _mapper.Map<School>(schoolDto);
            school.Id = Guid.NewGuid();
            Mock.Get(_repositoryWrapper.School).Setup(x => x.CreateSchool(school));
            Mock.Get(_repositoryWrapper.School).Setup(x => x.GetSchoolById(school.Id)).ReturnsAsync(school);
            var controller = new SchoolController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.CreateSchool(schoolDto).Result;
            // Assert 
            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
        }

        [TestMethod]
        public void UpdateSchool()
        {
            // Arrange
            var schoolDto = new SchoolDto
            {
                Name = "Update School 1"
            };
            var school = _mapper.Map<School>(schoolDto);
            school.Id = Guid.NewGuid();
            Mock.Get(_repositoryWrapper.School).Setup(x => x.UpdateSchool(school, school));
            Mock.Get(_repositoryWrapper.School).Setup(x => x.GetSchoolById(school.Id)).ReturnsAsync(school);
            var controller = new SchoolController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.UpdateSchool(school.Id, schoolDto).Result;
            // Assert 
            var noContentResult = actionResult as NoContentResult;
            Assert.IsNotNull(noContentResult);
        }

        // ToDo: Figure out why the mock setup for SchoolRepository.DeleteSchool() is not being mocked correctly 
        //[TestMethod]
        public void DeleteSchool()
        {
            // Arrange
            var school = DataSeeder.Schools[0];
            Mock.Get(_repositoryWrapper.School).Setup(x => x.DeleteSchool(school));
            Mock.Get(_repositoryWrapper.School).Setup(x => x.GetSchoolById(school.Id)).ReturnsAsync(school);
            Mock.Get(_repositoryWrapper.SchoolStudent).Setup(x => x.SchoolStudentsBySchool(school.Id)).ReturnsAsync(new List<SchoolStudent>());
            var controller = new SchoolController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.DeleteSchool(school.Id).Result;
            // Assert 
            var noContentResult = actionResult as NoContentResult;
            Assert.IsNotNull(noContentResult);
        }
    }
}
