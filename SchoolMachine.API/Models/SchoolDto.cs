using System.ComponentModel.DataAnnotations;

namespace SchoolMachine.API.Models
{
    public class SchoolDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }
    }
}
