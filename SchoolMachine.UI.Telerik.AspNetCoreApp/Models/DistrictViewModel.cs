using SchoolMachine.UI.Telerik.AspNetCoreApp.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace SchoolMachine.UI.Telerik.AspNetCoreApp.Models
{
    public class DistrictViewModel : ViewModelBase
    {
        [Display(Name = "Name")]
        [Required()]
        public string Name { get; set; }
    }
}
