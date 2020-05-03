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
    public class StudentsController : SchoolMachineBaseController
    {
        #region Constructors

        public StudentsController(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper)
        {
        }

        #endregion Constructors

        #region Views

        public IActionResult Create()
        {
            ViewData["Message"] = "Create a new student.";
            var model = new StudentViewModel();
            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }

        #endregion Views

        #region Data Operations

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var student = new Student
            {
                BirthDate = model.DateOfBirth,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName
            };
            var existingStudent = _repositoryWrapper.Student.FindByCondition(x => 
                x.LastName.Equals(student.LastName)
                && x.FirstName.Equals(student.FirstName)
                && x.MiddleName.Equals(student.MiddleName)
                && x.BirthDate.Equals(student.BirthDate)
            ).Result.FirstOrDefault();
            if (existingStudent == null)
            {
                _repositoryWrapper.Student.CreateStudent(student);
            }
            return View("Index");
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
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
