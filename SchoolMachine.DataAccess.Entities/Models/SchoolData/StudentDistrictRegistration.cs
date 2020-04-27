using SchoolMachine.DataAccess.Entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolMachine.DataAccess.Entities.Models.SchoolData
{
    [Table("student_district_registration", Schema = "schooldata")]
    public class StudentDistrictRegistration : IEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("district_id")]
        [Required(ErrorMessage = "SchoolDistrict Id is required")]
        public Guid DistrictId { get; set; }
        [JsonIgnore]
        public District District { get; set; }

        // Student Information

        [Column("student_first_name")]
        [Required(ErrorMessage = "StudentFirstName is required")]
        [StringLength(30, ErrorMessage = "StudentFirstName can't be longer than 30 characters")]
        public string StudentFirstName { get; set; }

        [Column("student_last_name")]
        [Required(ErrorMessage = "StudentLastName is required")]
        [StringLength(30, ErrorMessage = "StudentLastName can't be longer than 30 characters")]
        public string StudentLastName { get; set; }

        [Column("student_middle_name")]
        [Required(ErrorMessage = "StudentMiddleName is required")]
        [StringLength(20, ErrorMessage = "StudentMiddleName can't be longer than 20 characters")]
        public string StudentMiddleName { get; set; }

        [Column("student_birth_date")]
        [Required(ErrorMessage = "StudentBirthDate is required")]
        public DateTime StudentBirthDate { get; set; }

        // Guardian Information

        [Column("guardian_first_name")]
        [Required(ErrorMessage = "GuardianFirstName Name is required")]
        [StringLength(30, ErrorMessage = "GuardianFirstName can't be longer than 30 characters")]
        public string GuardianFirstName { get; set; }

        [Column("guardian_last_name")]
        [Required(ErrorMessage = "GuardianLast Name is required")]
        [StringLength(30, ErrorMessage = "GuardianLast Name can't be longer than 30 characters")]
        public string GuardianLastName { get; set; }

        [Column("guardian_middle_name")]
        [Required(ErrorMessage = "GuardianMiddleName is required")]
        [StringLength(20, ErrorMessage = "GuardianMiddleName can't be longer than 20 characters")]
        public string GuardianMiddleName { get; set; }

        [Column("guardian_phone")]
        [Required(ErrorMessage = "GuardianPhone is required")]
        [StringLength(20, ErrorMessage = "GuardianPhone can't be longer than 20 characters")]
        public string GuardianPhone { get; set; }

        // Student Resident Address

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

        // Registration Information

        [Column("registration_date")]
        public DateTime RegistrationDate { get; set; }

        [Column("registration_year")]
        public DateTime RegistrationYear { get; set; }
    }
}
