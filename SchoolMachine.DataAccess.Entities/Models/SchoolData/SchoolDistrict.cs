using SchoolMachine.DataAccess.Entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models.SchoolData
{
    [Table("school_districts", Schema = "school_data")]
    public class SchoolDistrict : IEntity
    {
        [Key]
        [Column("school_district_id")]
        public Guid Id { get; set; }

        [Column("name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }
    }
}
