using System.ComponentModel.DataAnnotations;

namespace SchoolMachine.API.Dtos
{
    public class DistrictDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }
    }
}
