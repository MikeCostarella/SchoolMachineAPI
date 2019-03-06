using Newtonsoft.Json;
using SchoolMachine.DataAccess.Entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.SchoolData.Models
{
    [Table("school_student", Schema = "schooldata")]
    public class SchoolStudent : IEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("school_id")]
        [Required(ErrorMessage = "School Id is required")]
        public Guid SchoolId { get; set; }
        [JsonIgnore]
        public School School { get; set; }

        [Column("student_id")]
        [Required(ErrorMessage = "Student Id is required")]
        public Guid StudentId { get; set; }
        [JsonIgnore]
        public Student Student { get; set; }

        [Column("grade_level")]
        [Required(ErrorMessage = "Grade Level is required")]
        public string GradeLevel { get; set; }

        [Column("registration_date")]
        [Required(ErrorMessage = "Registration date is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        [Column("date_created")]
        [Required(ErrorMessage = "Date created is required")]
        public DateTime DateCreated { get; set; }
    }
}
