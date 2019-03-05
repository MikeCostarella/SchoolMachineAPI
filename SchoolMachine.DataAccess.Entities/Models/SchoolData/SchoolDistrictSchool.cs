using SchoolMachine.DataAccess.Entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models.SchoolData
{
    [Table("SchoolDistrictSchools", Schema = "SchoolData")]
    public class SchoolDistrictSchool : IEntity
    {
        [Key]
        [Column("SchoolDistrictSchoolId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "SchoolDistrict Id is required")]
        public Guid SchoolDistrictId { get; set; }

        [Required(ErrorMessage = "School Id is required")]
        public Guid SchoolId { get; set; }

        [Required(ErrorMessage = "StartDate date is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Date created is required")]
        public DateTime DateCreated { get; set; }
    }
}
