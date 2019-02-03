using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SchoolMachine.DataAccess.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolMachine.Testing.API.Controllers.CRUD
{

    /// <summary>
    /// Perform mock unit tests on school controller actions
    /// </summary>
    [TestClass]
    public class SchoolControllerUnitTests
    {
        [TestMethod]
        public void GetAllSchools()
        {
            #region Setup

            var mockSchools = new List<School>()
            {
                new School  { Id = Guid.NewGuid(), Name = "Girard High School" },
                new School { Id = Guid.NewGuid(), Name = "Liberty High School" }
            };
            var employeeRepositoryMock = TestInitializer.MockSchoolRepository;
            var mock = employeeRepositoryMock.Setup(x => x.GetAllSchools());
            var taskResult = Task.FromResult(mockSchools);
            mock.Returns((IEnumerable<School>) taskResult.Result);

            #endregion Setup

            #region Test Logic

            //var response = httpClient.GetAsync("http://localhost:57872/api/school");
            var response = TestInitializer.TestHttpClient.GetAsync("api/school").Result;

            #endregion Test Logic

            #region Assertions

            Assert.AreEqual(response, null, String.Format("TestHttpClient"));
            var resp = response.Content.ReadAsStringAsync().Result;
            var responseData = JsonConvert.DeserializeObject<List<School>>(resp);
            Assert.AreEqual(responseData, null);
            Assert.AreEqual(3, responseData.Count);
            Assert.AreEqual(mockSchools[0].Id, responseData[0].Id);

            #endregion Assertions
        }

        [TestMethod]
        public void GetSchoolById()
        {
            #region Setup
            #endregion Setup

            #region Test Logic
            #endregion Test Logic

            #region Assertions
            #endregion Assertions
        }

        [TestMethod]
        public void GetSchoolWithDetails()
        {
            #region Setup
            #endregion Setup

            #region Test Logic
            #endregion Test Logic

            #region Assertions
            #endregion Assertions
        }

    }
}