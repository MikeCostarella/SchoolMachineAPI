using SchoolMachine.DataAccess.Entities.ExtendedModels;
using SchoolMachine.DataAccess.Entities.Models;
using System;
using System.Collections.Generic;

namespace SchoolMachine.Contracts.EntityRepositories
{
    public interface ISchoolRepository : IRepositoryBase<School>
    {
        IEnumerable<School> GetAllSchools();

        School GetSchoolById(Guid schoolId);

        SchoolExtended GetSchoolWithDetails(Guid schoolId);
    }
}
