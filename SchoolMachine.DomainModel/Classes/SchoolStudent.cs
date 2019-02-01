using SchoolMachine.DomainModel.Enumerations;
using SchoolMachine.DomainModel.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DomainModel.Classes
{
    [Table("SchoolStudents", Schema = "SchoolData")]
    public class SchoolStudent : IPersistentObject
    {
        [Key]
        public int Id { get; set; }

        public Guid Identifier { get; set; }

        //public int SchoolId { get; set; }
        public School School { get; set; }

        //public int StudentId { get; set; }
        public Student Student { get; set; }

        public GradeLevel GradeLevel { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    }
}
