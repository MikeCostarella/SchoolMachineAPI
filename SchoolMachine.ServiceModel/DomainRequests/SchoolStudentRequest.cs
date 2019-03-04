using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolMachine.ServiceModel.DomainRequests
{
    public class SchoolStudentRequest
    {
        public Guid SchoolId { get; set; }
        public int RecordStart { get; set; }
        public int NumberOfRecords { get; set; }
    }
}