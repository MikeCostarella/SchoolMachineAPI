using SchoolMachine.DataAccess.Entities.SchoolData.Models;
using SchoolMachine.ServiceModel.Enumerations;

namespace SchoolMachine.ServiceModel.DomainRequests
{
    public class StudentSchoolRegistrationRequest
    {
        public School School { get; set; }

        public Student Student { get; set; }

        public GradeLevel GradeLevel { get; set; }
    }
}
