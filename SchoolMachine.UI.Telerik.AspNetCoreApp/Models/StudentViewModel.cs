using SchoolMachine.UI.Telerik.AspNetCoreApp.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolMachine.UI.Telerik.AspNetCoreApp.Models
{
    public class StudentViewModel : ViewModelBase
    {
        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "Birth Date is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(30, ErrorMessage = "First Name can't be longer than 60 characters")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(30, ErrorMessage = "Last Name can't be longer than 60 characters")]
        public string LastName { get; set; }
        [Display(Name = "Middle Name")]
        [Required(ErrorMessage = "Middle Name is required")]
        [StringLength(20, ErrorMessage = "Middle Name can't be longer than 60 characters")]
        public string MiddleName { get; set; }
    }
}