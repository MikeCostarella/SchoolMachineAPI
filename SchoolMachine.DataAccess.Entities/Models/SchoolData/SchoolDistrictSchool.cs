using SchoolMachine.DataAccess.Entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models.SchoolData
{
    [Table("school_district_schools", Schema = "school_data")]
    public class SchoolDistrictSchool : IEntity
    {
        [Key]
        [Column("school_district_school_id")]
        public Guid Id { get; set; }

        [Column("school_district_id")]
        [Required(ErrorMessage = "SchoolDistrict Id is required")]
        public Guid SchoolDistrictId { get; set; }

        [Column("school_id")]
        [Required(ErrorMessage = "School Id is required")]
        public Guid SchoolId { get; set; }

        [Column("start_date")]
        [Required(ErrorMessage = "StartDate date is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        [Column("end_date")]
        public DateTime? EndDate { get; set; }

        [Column("date_created")]
        [Required(ErrorMessage = "Date created is required")]
        public DateTime DateCreated { get; set; }
    }
}
