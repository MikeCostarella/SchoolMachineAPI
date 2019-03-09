using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SchoolMachine.API.Controllers.CRUD;
using SchoolMachine.API.Dtos;
using SchoolMachine.API.UnitTests.Base;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using SchoolMachine.DataAccess.Entities.SeedData;
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
    public class SchoolStudentControllerUnitTests : BaseControllerUnitTests
    {
        [TestMethod]
        public void GetAllSchoolStudents()
        {
            // Arrange
            Mock.Get(_repositoryWrapper.SchoolStudent).Setup(x => x.GetAllSchoolStudents()).ReturnsAsync(DataSeeder.SchoolStudents);
            var controller = new SchoolStudentController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.GetAllSchoolStudents().Result;
            // Assert 
            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            var resultList = okObjectResult.Value as IEnumerable<SchoolStudent>;
            Assert.IsTrue(resultList.Count() == DataSeeder.SchoolStudents.Count());
        }

        [TestMethod]
        public void GetSchoolStudentById()
        {
            // Arrange
            var schoolStudent = DataSeeder.SchoolStudents.FirstOrDefault();
            Assert.IsNotNull(schoolStudent, string.Format("No school students were setup in the DataSeeder"));
            Mock.Get(_repositoryWrapper.SchoolStudent).Setup(x => x.GetSchoolStudentById(schoolStudent.Id)).ReturnsAsync(schoolStudent);
            var controller = new SchoolStudentController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.GetSchoolStudentById(schoolStudent.Id).Result;
            // Assert 
            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            var resultList = okObjectResult.Value as SchoolStudent;
            Assert.IsTrue(resultList.Id == schoolStudent.Id);
        }

        [TestMethod]
        public void CreateSchoolStudent()
        {
            // Arrange
            var schoolStudentDto = new SchoolStudentDto
            {
                GradeLevel = "9th",
                RegistrationDate = DateTime.UtcNow,
                SchoolId = DataSeeder.Schools[0].Id,
                StudentId = DataSeeder.Students[0].Id
            };
            var schoolStudent = _mapper.Map<SchoolStudent>(schoolStudentDto);
            Mock.Get(_repositoryWrapper.SchoolStudent).Setup(x => x.CreateSchoolStudent(schoolStudent));
            Mock.Get(_repositoryWrapper.SchoolStudent).Setup(x => x.GetSchoolStudentById(schoolStudent.Id)).ReturnsAsync(schoolStudent);
            var controller = new SchoolStudentController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.CreateSchoolStudent(schoolStudentDto).Result;
            // Assert 
            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
        }

        [TestMethod]
        public void UpdateSchoolStudent()
        {
            // Arrange
            var schoolStudentDto = new SchoolStudentDto
            {
                GradeLevel = "9th",
                RegistrationDate = DateTime.UtcNow,
                SchoolId = DataSeeder.Schools[0].Id,
                StudentId = DataSeeder.Students[0].Id
            };
            var schoolStudent = _mapper.Map<SchoolStudent>(schoolStudentDto);
            Mock.Get(_repositoryWrapper.SchoolStudent).Setup(x => x.UpdateSchoolStudent(schoolStudent, schoolStudent));
            Mock.Get(_repositoryWrapper.SchoolStudent).Setup(x => x.GetSchoolStudentById(schoolStudent.Id)).ReturnsAsync(schoolStudent);
            var controller = new SchoolStudentController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.UpdateSchoolStudent(schoolStudent.Id, schoolStudentDto).Result;
            // Assert 
            var noContentResult = actionResult as NoContentResult;
            Assert.IsNotNull(noContentResult);
        }

        // ToDo: Figure out why the mock setup for SchoolRepository.DeleteSchool() is not being mocked correctly 
        //[TestMethod]
        public void DeleteSchoolStudent()
        {
            // Arrange
            var schoolStudent = DataSeeder.SchoolStudents[0];
            Mock.Get(_repositoryWrapper.SchoolStudent).Setup(x => x.DeleteSchoolStudent(schoolStudent));
            Mock.Get(_repositoryWrapper.SchoolStudent).Setup(x => x.GetSchoolStudentById(schoolStudent.Id)).ReturnsAsync(schoolStudent);
            var controller = new SchoolStudentController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.DeleteSchoolStudent(schoolStudent.Id).Result;
            // Assert
            var noContentResult = actionResult as NoContentResult;
            Assert.IsNotNull(noContentResult);
        }
    }
}
