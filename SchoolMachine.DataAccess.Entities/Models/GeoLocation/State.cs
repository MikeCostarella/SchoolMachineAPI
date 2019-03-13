using Newtonsoft.Json;
using SchoolMachine.DataAccess.Entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models.Geolocation
{
    [Table("state", Schema = "geolocation")]
    public class State : INamedEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; }

        [Column("abbreviation")]
        [Required(ErrorMessage = "Abbreviation is required")]
        [StringLength(2, ErrorMessage = "Abbreviation can't be longer than 2 characters")]
        public string Abbreviation { get; set; }

        [Column("country_id")]
        [Required(ErrorMessage = "Country Id is required")]
        public Guid CountryId { get; set; }
        [JsonIgnore]
        public Country Country { get; set; }
    }
}
