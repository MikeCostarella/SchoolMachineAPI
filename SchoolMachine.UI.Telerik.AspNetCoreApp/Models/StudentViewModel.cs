using SchoolMachine.UI.Telerik.AspNetCoreApp.Models.Base;
using System;

namespace SchoolMachine.UI.Telerik.AspNetCoreApp.Models
{
    public class StudentViewModel : ViewModelBase
    {
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}