using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolMachine.UI.Telerik.AspNetCoreApp.Models.Base
{
    public abstract class ViewModelBase
    {
        [Display(Name = "Id")]
        [Required()]
        public Guid Id { get; set; }
    }
}
