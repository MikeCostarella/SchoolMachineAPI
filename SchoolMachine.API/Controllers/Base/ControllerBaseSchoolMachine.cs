using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.API.Models.Base;
using SchoolMachine.Contracts;

namespace SchoolMachine.API.Controllers.Base
{
    public class ControllerBaseSchoolMachine : ControllerBase
    {
        #region Member Variables

        protected ILoggerManager _loggerManager;
        protected IMapper _mapper;
        protected IRepositoryWrapper _repositoryWrapper;

        #endregion Member Variables

        #region Constructors

        public ControllerBaseSchoolMachine(ILoggerManager loggerManager, IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _loggerManager = loggerManager;
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        #endregion Constructors

        #region Logging

        protected void LogInformation(string message)
        {
            _loggerManager.LogInfo(message);
        }

        protected IBaseServiceResponse LogInformation(IBaseServiceResponse response, string message)
        {
            response.IsSuccessful = true;
            response.Message = message;
            LogInformation(response.Message);
            return response;
        }

        protected void LogError(string message)
        {
            _loggerManager.LogError(message);
        }

        protected IBaseServiceResponse LogError(IBaseServiceResponse response, string message)
        {
            response.IsSuccessful = false;
            response.Message = message;
            LogError(response.Message);
            return response;
        }

        #endregion Logging
    }
}
