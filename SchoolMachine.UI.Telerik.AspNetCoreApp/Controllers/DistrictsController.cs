using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.Contracts;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using SchoolMachine.UI.Telerik.AspNetCoreApp.Controllers.Base;
using SchoolMachine.UI.Telerik.AspNetCoreApp.Models;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult Create()
        {
            ViewData["Message"] = "Create a new district.";
            var model = new DistrictViewModel();
            return View(model);
        }

        #endregion Views

        #region Data Operations

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DistrictViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var district = new District
            {
                Name = model.Name,
            };
            var existingDistrict = _repositoryWrapper.District.FindByCondition(x => x.Name.Equals(district.Name)).Result.FirstOrDefault();
            if (existingDistrict == null)
            {
                _repositoryWrapper.District.CreateDistrict(district);
            }
            return View("Index");
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var districts = _repositoryWrapper.District.GetAllDistricts().Result;
            var districtViewModels = new List<DistrictViewModel>();
            foreach (var district in districts)
            {
                var districtViewModel = new DistrictViewModel();
                districtViewModel.Id = district.Id;
                districtViewModel.Name = district.Name;
                districtViewModels.Add(districtViewModel);
            }
            var dsResult = districtViewModels.ToDataSourceResult(request);
            return Json(dsResult);
        }

        #endregion Data Operations
    }
}
