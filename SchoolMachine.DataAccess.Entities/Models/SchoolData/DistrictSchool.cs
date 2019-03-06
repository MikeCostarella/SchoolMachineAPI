using Newtonsoft.Json;
using SchoolMachine.DataAccess.Entities.Interfaces;
using SchoolMachine.DataAccess.Entities.SchoolData.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models.SchoolData
{
    [Table("district_school", Schema = "schooldata")]
    public class DistrictSchool : IEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("district_id")]
        [Required(ErrorMessage = "SchoolDistrict Id is required")]
        public Guid DistrictId { get; set; }
        [JsonIgnore]
        public District District { get; set; }

        [Column("school_id")]
        [Required(ErrorMessage = "School Id is required")]
        public Guid SchoolId { get; set; }
        [JsonIgnore]
        public School School { get; set; }

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
