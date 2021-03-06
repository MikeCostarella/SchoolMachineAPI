﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SchoolMachine.API.Controllers;
using SchoolMachine.API.Models;
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
    public class StudentControllerUnitTests : BaseControllerUnitTests
    {
        [TestMethod]
        public void GetAllStudents()
        {
            // Arrange
            Mock.Get(_repositoryWrapper.Student).Setup(x => x.GetAllStudents()).ReturnsAsync(DataSeeder.StudentSeeder.Objects);
            var controller = new StudentController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.GetAllStudents().Result;
            // Assert 
            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            var results = okObjectResult.Value as IEnumerable<Student>;
            Assert.IsTrue(results.Count() == DataSeeder.StudentSeeder.Objects.Count());
        }

        [TestMethod]
        public void GetStudentById()
        {
            // Arrange
            var student = DataSeeder.StudentSeeder.Objects.FirstOrDefault();
            Assert.IsNotNull(student, string.Format("No students were setup in the data seeder"));
            Mock.Get(_repositoryWrapper.Student).Setup(x => x.GetStudentById(student.Id)).ReturnsAsync(student);
            var controller = new StudentController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.GetStudentById(student.Id).Result;
            // Assert 
            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            var resultObject = okObjectResult.Value as Student;
            Assert.IsTrue(resultObject.Id == student.Id);
        }

        [TestMethod]
        public void CreateStudent()
        {
            // Arrange
            var studentDto = new StudentDto
            {
                BirthDate = DateTime.UtcNow,
                FirstName = "Jane",
                LastName = "Doe",
                MiddleName = "A"
            };
            var student = _mapper.Map<Student>(studentDto);
            Mock.Get(_repositoryWrapper.Student).Setup(x => x.CreateStudent(student));
            Mock.Get(_repositoryWrapper.Student).Setup(x => x.GetStudentById(student.Id)).ReturnsAsync(student);
            var controller = new StudentController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.CreateStudent(studentDto).Result;
            // Assert 
            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
        }

        [TestMethod]
        public void UpdateStudent()
        {
            // Arrange
            var studentDto = new StudentDto
            {
                BirthDate = DateTime.UtcNow,
                FirstName = "Jane",
                LastName = "Doe",
                MiddleName = "A"
            };
            var student = _mapper.Map<Student>(studentDto);
            Mock.Get(_repositoryWrapper.Student).Setup(x => x.UpdateStudent(student, student));
            Mock.Get(_repositoryWrapper.Student).Setup(x => x.GetStudentById(student.Id)).ReturnsAsync(student);
            var controller = new StudentController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.UpdateStudent(student.Id, studentDto).Result;
            // Assert 
            var noContentResult = actionResult as NoContentResult;
            Assert.IsNotNull(noContentResult);
        }

        // ToDo: Figure out why the mock setup for SchoolRepository.DeleteSchool() is not being mocked correctly 
        //[TestMethod]
        public void DeleteStudent()
        {
            // Arrange
            var student = DataSeeder.StudentSeeder.Objects.FirstOrDefault();
            Assert.IsTrue(student != null, "No students setup in the data seeder");
            Mock.Get(_repositoryWrapper.Student).Setup(x => x.DeleteStudent(student));
            Mock.Get(_repositoryWrapper.Student).Setup(x => x.GetStudentById(student.Id)).ReturnsAsync(student);
            Mock.Get(_repositoryWrapper.SchoolStudent).Setup(x => x.SchoolStudentsByStudent(student.Id)).ReturnsAsync(new List<SchoolStudent>());
            var controller = new StudentController(_loggerManager, _mapper, _repositoryWrapper);
            // Act
            var actionResult = controller.DeleteStudent(student.Id).Result;
            // Assert 
            var noContentResult = actionResult as NoContentResult;
            Assert.IsNotNull(noContentResult);
        }
    }
}
