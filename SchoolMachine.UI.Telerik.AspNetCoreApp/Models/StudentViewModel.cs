using SchoolMachine.UI.Telerik.AspNetCoreApp.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolMachine.UI.Telerik.AspNetCoreApp.Models
{
    public class StudentViewModel : ViewModelBase
    {
        [Display(Name = "Birth Date")]
        [Required()]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "First Name")]
        [Required()]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required()]
        public string LastName { get; set; }
        [Display(Name = "Middle Name")]
        [Required()]
        public string MiddleName { get; set; }
    }
}