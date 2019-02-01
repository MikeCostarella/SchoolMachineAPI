using SchoolMachine.ServiceModel.Interfaces;
using System;

namespace SchoolMachine.ServiceModel.Classes
{
    public class School : IServiceModelObject
    {
        public Guid Identifier { get; set; }

        public string Name { get; set; }
    }
}
