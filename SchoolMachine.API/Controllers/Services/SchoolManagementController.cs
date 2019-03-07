using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.API.Controllers.Base;
using SchoolMachine.Contracts;
using SchoolMachine.ServiceModel.DomainRequests;
using SchoolMachine.ServiceModel.DomainResponses;
using System.Threading.Tasks;

namespace SchoolMachine.API.Controllers
{
    /// <summary>
    /// Will provide domain level services for schools
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
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
        [HttpPost("RegisterStudentForSchool", Name = "RegisterStudentForSchool")]
        public async Task<IActionResult> RegisterStudentForSchool([FromBody] StudentRegistrationRequest request)
        {
            await Task.Delay(0);
            // TODO: fill in logic
            return Ok(new StudentRegistrationResponse());
        }

        #endregion Action Methods
    }
}