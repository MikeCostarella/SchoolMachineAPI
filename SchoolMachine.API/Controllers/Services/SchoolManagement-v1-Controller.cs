using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.API.Controllers.Base;
using SchoolMachine.API.Models;
using SchoolMachine.Contracts;
using System;
using System.Threading.Tasks;

namespace SchoolMachine.API.Controllers
{
    /// <summary>
    /// Will provide domain level services for schools
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiversion}/[controller]")]
    [Produces("application/json")]
    public class SchoolManagementController : ControllerBaseSchoolMachine
    {
        #region Constructors

        public SchoolManagementController(ILoggerManager loggerManager, IMapper mapper, IRepositoryWrapper repositoryWrapper)
            : base(loggerManager, mapper, repositoryWrapper)
        {
        }

        #endregion Constructors

        #region Action Methods

        /// <summary>
        /// Registers a student into a School
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("StudentDistrictRegistration", Name = "StudentDistrictRegistration")]
        [ProducesResponseType(typeof(StudentDistrictRegistrationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> StudentDistrictRegistration([FromBody] StudentDistrictRegistrationRequest request)
        {
            await Task.Delay(0);
            try
            {
                // TODO: fill in logic
                return Ok(new StudentDistrictRegistrationResponse());
            }
            catch(Exception ex)
            {
                // TODO: Add logging
                return StatusCode(500, "Internal Server Error");
            }
        }

        #endregion Action Methods
    }
}