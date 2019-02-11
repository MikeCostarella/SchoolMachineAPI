using SchoolMachine.DataAccess.Entities.SchoolData.Models;
using System;
using System.Collections.Generic;

namespace SchoolMachine.DataAccess.Entities.ExtendedModels
{
    public class StudentExtended
    {
        #region Concrete Properties

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime BirthDate { get; set; }

        #endregion Properties

        #region Navigation properties

        public IEnumerable<SchoolStudent> Schools { get; set; }

        #endregion Navigation Properties

        #region Constructors

        public StudentExtended()
        {
        }

        public StudentExtended(Student student)
        {
            Id = student.Id;

            FirstName = student.FirstName;

            MiddleName = student.MiddleName;

            BirthDate = student.BirthDate;
        }

        #endregion Constructors
    }
}
