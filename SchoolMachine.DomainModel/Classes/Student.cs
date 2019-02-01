using SchoolMachine.DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DomainModel.Classes
{
    [Table("Students", Schema = "SchoolData")]
    public class Student : IPersistentObject
    {
        [Key]
        public int Id { get; set; }

        public Guid Identifier { get; set; }

        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        [MaxLength(30)]
        public string MiddleName { get; set; }

        public DateTime BirthDate { get; set; }

        //Navigation Properties
        public ICollection<SchoolStudent> Schools { get; set; }
    }
}
