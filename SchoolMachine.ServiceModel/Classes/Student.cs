using SchoolMachine.ServiceModel.Interfaces;
using System;

namespace SchoolMachine.ServiceModel.Classes
{
    public class Student : IServiceModelObject
    {
        public Guid Identifier { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
