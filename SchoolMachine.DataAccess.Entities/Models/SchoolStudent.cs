﻿using SchoolMachine.DataAccess.Entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models
{
    [Table("SchoolStudents", Schema = "SchoolData")]
    public class SchoolStudent : IEntity
    {
        [Key]
        [Column("SchoolStudentId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "School Id is required")]
        public Guid SchoolId { get; set; }

        [Required(ErrorMessage = "Student Id is required")]
        public Guid StudentId { get; set; }

        [Required(ErrorMessage = "Grade Level is required")]
        public string GradeLevel { get; set; }

        [Required(ErrorMessage = "Registration date is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Date created is required")]
        public DateTime DateCreated { get; set; }
    }
}
