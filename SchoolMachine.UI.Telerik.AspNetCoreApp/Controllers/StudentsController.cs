using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.Contracts;
using SchoolMachine.UI.Telerik.AspNetCoreApp.Controllers.Base;
using SchoolMachine.UI.Telerik.AspNetCoreApp.Models;
using System.Collections.Generic;

namespace SchoolMachine.UI.Telerik.AspNetCoreApp.Controllers
{
    public class StudentsController : SchoolMachineBaseController
    {
        #region Constructors

        public StudentsController(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper)
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

        public ActionResult Students_Read([DataSourceRequest]DataSourceRequest request)
        {
            var students = _repositoryWrapper.Student.GetAllStudents().Result;
            var studentViewModels = new List<StudentViewModel>();
            foreach (var student in students)
            {
                var studentViewModel = new StudentViewModel();
                studentViewModel.Id = student.Id;
                studentViewModel.DateOfBirth = student.BirthDate;
                studentViewModel.FirstName = student.FirstName;
                studentViewModel.MiddleName = student.MiddleName;
                studentViewModel.LastName = student.LastName;
                studentViewModels.Add(studentViewModel);
            }
            var dsResult = studentViewModels.ToDataSourceResult(request);
            return Json(dsResult);
        }

        #endregion Data Operations
    }
}
