using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolMachine.DataAccess.Entities.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
