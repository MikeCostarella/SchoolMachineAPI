using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.API.Controllers.Base;
using SchoolMachine.Contracts;
using SchoolMachine.ServiceModel.DomainRequests;
using SchoolMachine.ServiceModel.DomainResponses;
using System.Threading.Tasks;

namespace SchoolMachine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolStudentRegistrationController : ControllerBaseSchoolMachine
    {
        #region Constructors

        public SchoolStudentRegistrationController(ILoggerManager loggerManager, IMapper mapper, IRepositoryWrapper repositoryWrapper)
            : base(loggerManager, mapper, repositoryWrapper)
        {
        }

        #endregion Constructors

        #region Action Methods

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentSchoolRegistrationRequest value)
        {
            await Task.Delay(0);
            // TODO: fill in logic
            return Ok(new StudentSchoolRegistrationResponse());
        }

        #endregion Action Methods
    }
}