using SchoolMachine.DataAccess.Entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.SchoolData.Models
{
    [Table("students", Schema = "school_data")]
    public class Student : IEntity
    {
        [Key]
        [Column("student_id")]
        public Guid Id { get; set; }

        [Column("first_name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(60, ErrorMessage = "First Name can't be longer than 60 characters")]
        public string FirstName { get; set; }

        [Column("last_name")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(60, ErrorMessage = "Last Name can't be longer than 60 characters")]
        public string LastName { get; set; }

        [Column("middle_name")]
        [Required(ErrorMessage = "Middle Name is required")]
        [StringLength(60, ErrorMessage = "Middle Name can't be longer than 60 characters")]
        public string MiddleName { get; set; }

        [Column("birth_date")]
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime BirthDate { get; set; }
    }
}
