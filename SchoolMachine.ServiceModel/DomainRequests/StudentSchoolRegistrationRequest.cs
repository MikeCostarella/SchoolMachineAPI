using SchoolMachine.ServiceModel.Enumerations;
using System;

namespace SchoolMachine.ServiceModel.DomainRequests
{
    public class StudentSchoolRegistrationRequest
    {
        public Guid SchoolId { get; set; }

        public Guid StudentId { get; set; }

        public GradeLevel GradeLevel { get; set; }
    }
}
