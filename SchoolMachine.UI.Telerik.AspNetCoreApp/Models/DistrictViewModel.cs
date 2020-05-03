using SchoolMachine.UI.Telerik.AspNetCoreApp.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace SchoolMachine.UI.Telerik.AspNetCoreApp.Models
{
    public class DistrictViewModel : ViewModelBase
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }
    }
}
