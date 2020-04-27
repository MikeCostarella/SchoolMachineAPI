using System;

namespace SchoolMachine.API.Models
{
    public class StudentDistrictRegistrationRequest
    {
        public Guid Id { get; set; }
        public Guid DistrictId { get; set; }

        // Student Information
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentMiddleName { get; set; }
        public DateTime StudentBirthDate { get; set; }

        // Guardian Information
        public string GuardianFirstName { get; set; }
        public string GuardianLastName { get; set; }
        public string GuardianMiddleName { get; set; }
        public string GuardianPhone { get; set; }

        // Student Resident Address
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        // Registration Information
        public DateTime RegistrationDate { get; set; }
        public DateTime RegistrationYear { get; set; }
    }
}
