using SchoolMachine.UI.Telerik.AspNetCoreApp.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolMachine.UI.Telerik.AspNetCoreApp.Models
{
    public class StudentViewModel : ViewModelBase
    {
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}