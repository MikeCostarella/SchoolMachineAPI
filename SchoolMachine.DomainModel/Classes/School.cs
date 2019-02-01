using SchoolMachine.DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DomainModel.Classes
{
    [Table("Schools", Schema = "SchoolData")]
    public class School : IPersistentObject
    {
        [Key]
        public int Id { get; set; }

        public Guid Identifier { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        //Navigation Properties
        public ICollection<SchoolStudent> Students { get; set; }
    }
}

