using System;

namespace SchoolMachine.DomainModel.Interfaces
{
    public interface IPersistentObject
    {
        int Id { get; set; }

        Guid Identifier { get; set; }
    }
}
