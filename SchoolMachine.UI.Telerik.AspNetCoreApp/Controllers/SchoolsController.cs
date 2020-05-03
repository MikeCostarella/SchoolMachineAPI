using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.Contracts;
using SchoolMachine.UI.Telerik.AspNetCoreApp.Controllers.Base;
using SchoolMachine.UI.Telerik.AspNetCoreApp.Models;
using System.Collections.Generic;

namespace SchoolMachine.UI.Telerik.AspNetCoreApp.Controllers
{
    public class SchoolsController : SchoolMachineBaseController
    {
        #region Constructors

        public SchoolsController(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper)
        {

        }

        #endregion Constructors

        #region Views

        public IActionResult Index()
        {
            return View();
        }

        #endregion Views

        #region Data Operations

        public ActionResult Schools_Read([DataSourceRequest]DataSourceRequest request)
        {
            var schools = _repositoryWrapper.School.GetAllSchools().Result;
            var schoolViewModels = new List<SchoolViewModel>();
            foreach (var student in schools)
            {
                var schoolViewModel = new SchoolViewModel();
                schoolViewModel.Id = student.Id;
                schoolViewModel.Name = student.Name;
            }
            var dsResult = schoolViewModels.ToDataSourceResult(request);
            return Json(dsResult);
        }

        #endregion Data Operations
    }
}
