using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SchoolMachine.DataAccess.Entities.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMachine.Testing.API.Controllers.CRUD
{
    [TestClass]
    public class SchoolControllerTests
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
            employeeRepositoryMock.Setup(x => x.GetAllSchools()).Returns((IEnumerable<School>) Task.FromResult(mockSchools));

            #endregion Setup

            #region Test Logic

            //var response = httpClient.GetAsync("http://localhost:57872/api/school");
            var response = TestInitializer.TestHttpClient.GetAsync("api/school").Result;

            #endregion Test Logic

            #region Assertions

            var resp = response.Content.ReadAsStringAsync().Result;
            var responseData = JsonConvert.DeserializeObject<List<School>>(resp);
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

            #region Tear Down
            #endregion Tear Down
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

            #region Tear Down
            #endregion Tear Down
        }

    }
}