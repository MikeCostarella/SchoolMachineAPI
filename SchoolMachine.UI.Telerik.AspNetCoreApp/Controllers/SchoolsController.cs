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

        public IActionResult Create()
        {
            ViewData["Message"] = "Create a new school.";
            var model = new SchoolViewModel();
            return View(model);
        }

        #endregion Views

        #region Data Operations

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SchoolViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var school = new School
            {
                Name = model.Name,
            };
            var existingSchool = _repositoryWrapper.School.FindByCondition(x => x.Name.Equals(school.Name)).Result.FirstOrDefault();
            if (existingSchool == null)
            {
                _repositoryWrapper.School.CreateSchool(school);
            }
            return View("Index");
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var schools = _repositoryWrapper.School.GetAllSchools().Result;
            var schoolViewModels = new List<SchoolViewModel>();
            foreach (var student in schools)
            {
                var schoolViewModel = new SchoolViewModel();
                schoolViewModel.Id = student.Id;
                schoolViewModel.Name = student.Name;
                schoolViewModels.Add(schoolViewModel);
            }
            var dsResult = schoolViewModels.ToDataSourceResult(request);
            return Json(dsResult);
        }

        #endregion Data Operations
    }
}
