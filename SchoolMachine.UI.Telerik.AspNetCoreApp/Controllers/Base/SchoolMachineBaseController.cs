using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.Contracts;

namespace SchoolMachine.UI.Telerik.AspNetCoreApp.Controllers.Base
{
    public class SchoolMachineBaseController : Controller
    {
        #region Member Variables

        protected IRepositoryWrapper _repositoryWrapper;

        #endregion Member Variables

        #region Constructors

        public SchoolMachineBaseController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        #endregion Constructors
    }
}
