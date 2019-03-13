using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SchoolMachine.DataAccess.Entities.Models.Geolocation;
using SchoolMachine.DataAccess.Entities.SeedData;
using SchoolMachine.Testing.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolMachine.Testing.API.Controllers.Geolocation
{
    /// <summary>
    /// Performs integration tests on GeolocationController action methods
    /// </summary>
    [TestClass]
    public class GeolocationControllerIntegrationTests : SchoolMachineApiIntegrationTestBase
    {
        #region Action Tests

        [TestMethod]
        public void GetAllCountries()
        {
            try
            {
                // Act
                var response = Client.GetAsync("api/geolocation/GetAllCountries/").Result;
                // Assert
                response.EnsureSuccessStatusCode();
                var jsonString = response.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<Country>>(jsonString);
                var expectedList = DataSeeder.CountrySeeder.Objects;
                Assert.IsTrue(list.Count >= expectedList.Count, string.Format("{0} objects were returned from the service call but {1} objects were seeded", list.Count, expectedList.Count));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GetStatesByCountryId()
        {
            // Assert
            var response1 = Client.GetAsync("api/geolocation/GetAllCountries/").Result;
            var countries = JsonConvert.DeserializeObject<List<Country>>(response1.Content.ReadAsStringAsync().Result);
            var country = countries.FirstOrDefault(c => c.Name == "United States");
            Assert.IsNotNull(country, "United States was not found.");
            // Act
            var response = Client.GetAsync("api/geolocation/GetStatesByCountryId/?countryId=" + country.Id.ToString()).Result;
            // Assert
            response.EnsureSuccessStatusCode();
            var jsonString = response.Content.ReadAsStringAsync().Result;
            var list = JsonConvert.DeserializeObject<List<State>>(jsonString);
            var expectedCountry = DataSeeder.CountrySeeder.Objects.FirstOrDefault(c => c.Name == "United States");
            var expectedList = DataSeeder.StateSeeder.Objects.Where(s => s.CountryId == expectedCountry.Id);
            Assert.IsTrue(list.Count() == expectedList.Count(), string.Format("{0} objects were returned from the service call but {1} objects were seeded", list.Count(), expectedList.Count()));
        }

        #endregion Action Tests
    }
}
