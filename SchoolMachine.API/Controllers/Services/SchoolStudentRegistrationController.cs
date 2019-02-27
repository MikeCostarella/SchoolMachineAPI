using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.API.Controllers.Base;
using SchoolMachine.Contracts;
using SchoolMachine.ServiceModel.DomainRequests;
using SchoolMachine.ServiceModel.DomainResponses;

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
        public StudentSchoolRegistrationResponse Post([FromBody] StudentSchoolRegistrationRequest value)
        {
            // TODO: fill in logic
            return new StudentSchoolRegistrationResponse();
        }

        #endregion Action Methods
    }
}