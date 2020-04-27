namespace SchoolMachine.DataAccess.Entities.Models.SchoolData.Extensions
{
    public static class StudentDistrictRegistrationExtensions
    {
        // ToDo: Replace this with automapper call
        public static void Map(this StudentDistrictRegistration dbStudentDistrictRegistration, StudentDistrictRegistration studentDistrictRegistration)
        {
            dbStudentDistrictRegistration.City = studentDistrictRegistration.City;
            dbStudentDistrictRegistration.Country = studentDistrictRegistration.Country;
            dbStudentDistrictRegistration.District = studentDistrictRegistration.District;
            dbStudentDistrictRegistration.DistrictId = studentDistrictRegistration.DistrictId;
            dbStudentDistrictRegistration.GuardianFirstName = studentDistrictRegistration.GuardianFirstName;
            dbStudentDistrictRegistration.GuardianLastName = studentDistrictRegistration.GuardianLastName;
            dbStudentDistrictRegistration.GuardianMiddleName = studentDistrictRegistration.GuardianMiddleName;
            dbStudentDistrictRegistration.GuardianPhone = studentDistrictRegistration.GuardianPhone;
            dbStudentDistrictRegistration.PostalCode = studentDistrictRegistration.PostalCode;
            dbStudentDistrictRegistration.RegistrationDate = studentDistrictRegistration.RegistrationDate;
            dbStudentDistrictRegistration.RegistrationYear = studentDistrictRegistration.RegistrationYear;
            dbStudentDistrictRegistration.State = studentDistrictRegistration.State;
            dbStudentDistrictRegistration.Street1 = studentDistrictRegistration.Street1;
            dbStudentDistrictRegistration.Street2 = studentDistrictRegistration.Street2;
            dbStudentDistrictRegistration.StudentBirthDate = studentDistrictRegistration.StudentBirthDate;
            dbStudentDistrictRegistration.StudentFirstName = studentDistrictRegistration.StudentFirstName;
            dbStudentDistrictRegistration.StudentLastName = studentDistrictRegistration.StudentLastName;
            dbStudentDistrictRegistration.StudentMiddleName = studentDistrictRegistration.StudentMiddleName;
        }
    }
}
