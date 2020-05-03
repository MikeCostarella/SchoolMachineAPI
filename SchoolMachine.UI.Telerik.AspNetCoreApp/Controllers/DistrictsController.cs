using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.Contracts;
using SchoolMachine.UI.Telerik.AspNetCoreApp.Controllers.Base;
using SchoolMachine.UI.Telerik.AspNetCoreApp.Models;
using System.Collections.Generic;

namespace SchoolMachine.UI.Telerik.AspNetCoreApp.Controllers
{
    public class DistrictsController : SchoolMachineBaseController
    {
        #region Constructors

        public DistrictsController(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper)
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

        public ActionResult Districts_Read([DataSourceRequest]DataSourceRequest request)
        {
            var districts = _repositoryWrapper.District.GetAllDistricts().Result;
            var districtViewModels = new List<DistrictViewModel>();
            foreach (var district in districts)
            {
                var districtViewModel = new DistrictViewModel();
                districtViewModel.Id = district.Id;
                districtViewModel.Name = district.Name;
            }
            var dsResult = districtViewModels.ToDataSourceResult(request);
            return Json(dsResult);
        }

        #endregion Data Operations
    }
}
