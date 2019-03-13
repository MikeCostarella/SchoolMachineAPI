using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SchoolMachine.API;
using SchoolMachine.API.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using SchoolMachine.DataAccess.Entities.Interfaces;
using System;

namespace SchoolMachine.Testing.API.Base
{
    public class SchoolMachineApiIntegrationTestBase
    {
        #region Constructors

        public SchoolMachineApiIntegrationTestBase()
        {
            WebApplicationFactory = new WebApplicationFactory<Startup>();
            Client = WebApplicationFactory.CreateClient();
        }

        #endregion Constructors

        #region Public Properties

        /// <summary>
        /// A factory to create a test server for the SchoolMachineAPI project
        /// </summary>
        public WebApplicationFactory<Startup> WebApplicationFactory { get; set; }

        /// <summary>
        /// An http client to make service calls to SchoolMachineAPI
        /// </summary>
        public HttpClient Client { get; set; }

        #endregion Public Properties

        #region Generic Tests

        public void Test_GetAllObjects<T>(string route, List<T> expectedObjects)
        {
            try
            {
                // Act
                var testObjects = (List<T>)Client.GetObjectAsync<List<T>>(route);
                // Assert
                Assert.IsTrue(testObjects.Count >= expectedObjects.Count,
                    string.Format("{0} testObjects were returned from the service call but {1} expectedObjects were seeded", testObjects.Count, expectedObjects.Count));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        public void Test_GetNamedEntityById<T>(string route)
        {
            try
            {
                // Arrange
                var arrangementObject = (INamedEntity)(((List<T>)Client.GetObjectAsync<List<T>>(route)).FirstOrDefault());
                Assert.IsNotNull(arrangementObject, "No arrangementObject(s) returned from setup service call.");
                // Act
                var response = Client.GetAsync(route + arrangementObject.Id.ToString()).Result;
                // Assert
                response.EnsureSuccessStatusCode();
                var jsonString = response.Content.ReadAsStringAsync().Result;
                var testObject = (INamedEntity) JsonConvert.DeserializeObject<T>(jsonString);
                Assert.IsNotNull(testObject, "Returned testObject was null");
                Assert.IsTrue(testObject.Name == arrangementObject.Name, string.Format("Test object name {0} is not eqaul to expected arrangementObject name {1}", testObject.Name, arrangementObject.Name));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        #endregion Generic Tests
    }
}
