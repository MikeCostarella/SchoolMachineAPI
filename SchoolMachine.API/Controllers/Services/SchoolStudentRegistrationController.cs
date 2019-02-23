using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.Contracts;
using SchoolMachine.ServiceModel.DomainRequests;
using SchoolMachine.ServiceModel.DomainResponses;

namespace SchoolMachine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolStudentRegistrationController : ControllerBase
    {
        #region Private Variables

        private ILoggerManager _loggerManager;
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;

        #endregion Private Variables

        #region Constructors

        public SchoolStudentRegistrationController(ILoggerManager loggerManager, IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _loggerManager = loggerManager;
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        #endregion Constructors

        [HttpPost]
        public StudentSchoolRegistrationResponse Post([FromBody] StudentSchoolRegistrationRequest value)
        {
            // TODO: fill in logic
            return new StudentSchoolRegistrationResponse();
        }
    }
}