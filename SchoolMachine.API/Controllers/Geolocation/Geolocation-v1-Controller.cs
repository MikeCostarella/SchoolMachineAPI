using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.API.Controllers.Base;
using SchoolMachine.Contracts;

namespace SchoolMachine.API.Controllers.Geolocation
{
    /// <summary>
    /// Provides functionality for geolocation schema entities.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiversion}/[controller]")]
    [Produces("application/json")]
    public class GeolocationController : ControllerBaseSchoolMachine
    {
        #region Constructors

        public GeolocationController(ILoggerManager loggerManager, IMapper mapper, IRepositoryWrapper repositoryWrapper)
            : base(loggerManager, mapper, repositoryWrapper)
        {
        }

        #endregion Constructors

        #region Actions

        /// <summary>
        /// Gets all countries from the data store
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllCountries", Name = "GetAllCountries")]
        public async Task<IActionResult> GetAllCountries()
        {
            try
            {
                var countries = await _repositoryWrapper.Country.GetAllCountries();
                _loggerManager.LogInfo($"Returned all countries from database.");
                return Ok(countries);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside GetAllCountries action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Gets States from the repository by a unique Country id
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        [HttpGet("GetStatesByCountryId", Name = "GetStatesByCountryId")]
        public async Task<IActionResult> GetStatesByCountryId(Guid countryId)
        {
            try
            {
                var countries = await _repositoryWrapper.State.GetStatesByCountryId(countryId);
                _loggerManager.LogInfo($"Returned { countries.Count() } States from repository for Country { countryId }.");
                return Ok(countries);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside GetStatesByCountryId action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion Actions

    }
}
