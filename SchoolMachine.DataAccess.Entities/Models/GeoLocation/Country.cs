using Newtonsoft.Json;
using SchoolMachine.DataAccess.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models.Geolocation
{
    [Table("country", Schema = "geolocation")]
    public class Country : IEntity, INamedEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }

        [Column("abbreviation")]
        [Required(ErrorMessage = "Abbreviation is required")]
        [StringLength(2, ErrorMessage = "Abbreviation can't be longer than 2 characters")]
        public string Abbreviation { get; set; }

        [JsonIgnore]
        public List<State> States { get; set; }
    }
}
