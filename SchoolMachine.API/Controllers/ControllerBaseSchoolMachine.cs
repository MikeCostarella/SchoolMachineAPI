using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.Contracts;

namespace SchoolMachine.API.Controllers
{
    public class ControllerBaseSchoolMachine : ControllerBase
    {
        #region Private Variables

        protected ILoggerManager _loggerManager;
        protected IMapper _mapper;
        protected IRepositoryWrapper _repositoryWrapper;

        #endregion Private Variables

        #region Constructors

        public ControllerBaseSchoolMachine(ILoggerManager loggerManager, IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _loggerManager = loggerManager;
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        #endregion Constructors
    }
}
