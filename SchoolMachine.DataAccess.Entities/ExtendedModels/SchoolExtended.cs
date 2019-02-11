using SchoolMachine.DataAccess.Entities.SchoolData.Models;
using System;
using System.Collections.Generic;

namespace SchoolMachine.DataAccess.Entities.ExtendedModels
{
    public class SchoolExtended
    {
        #region Concrete Properties

        public Guid Id { get; set; }

        public string Name { get; set; }

        #endregion Concrete Properties

        #region Navigation Properties

        public IEnumerable<SchoolStudent> Students { get; set; }

        #endregion Navigation Properties

        #region Constructors

        public SchoolExtended()
        {
        }

        public SchoolExtended(School school)
        {
            Id = school.Id;

            Name = school.Name;
        }

        #endregion Constructors
    }
}
