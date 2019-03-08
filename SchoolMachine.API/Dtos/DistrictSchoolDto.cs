using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.API.Dtos
{
    public class DistrictSchoolDto
    {
        [Required(ErrorMessage = "DistrictId Id is required")]
        public Guid DistrictId { get; set; }

        [Required(ErrorMessage = "SchoolId Id is required")]
        public Guid SchoolId { get; set; }

        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "StartDate date is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
    }
}
