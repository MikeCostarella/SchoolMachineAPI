using SchoolMachine.DataAccess.Entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models.SchoolData
{
    /// <summary>
    /// Represents a physical address or geolocation
    /// </summary>
    [Table("location", Schema = "schooldata")]
    public class Location : IEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("description")]
        [StringLength(200, ErrorMessage = "Description can't be longer than 200 characters")]
        public string Description { get; set; }

        [Column("street1")]
        [StringLength(50, ErrorMessage = "Street1 can't be longer than 50 characters")]
        public string Street1 { get; set; }

        [Column("street2")]
        [StringLength(50, ErrorMessage = "Street2 can't be longer than 50 characters")]
        public string Street2 { get; set; }

        [Column("city")]
        [StringLength(50, ErrorMessage = "City can't be longer than 50 characters")]
        public string City { get; set; }

        [Column("state")]
        [StringLength(20, ErrorMessage = "State can't be longer than 20 characters")]
        public string State { get; set; }

        [Column("postal_code")]
        [StringLength(20, ErrorMessage = "PostalCode can't be longer than 20 characters")]
        public string PostalCode { get; set; }

        [Column("country")]
        [StringLength(50, ErrorMessage = "Country can't be longer than 50 characters")]
        public string Country { get; set; }

        [Column("longitude")]
        public Double Longitude { get; set; }

        [Column("latitude")]
        public Double Latitude { get; set; }
    }
}
