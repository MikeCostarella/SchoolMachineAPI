using System;

namespace SchoolMachine.ServiceModel.DomainResponses
{
    public class StudentSchoolRegistrationResponse
    {
        public Guid Indentifier { get; set; }

        public bool RequestStatus { get; set; }

        public string Message { get; set; }
    }
}
