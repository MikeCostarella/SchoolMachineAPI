using System;

namespace SchoolMachine.DataAccess.Entities.Interfaces
{
    public interface INamedEntity
    {
        Guid Id { get; set; }
        string Name { get; }
    }
}
