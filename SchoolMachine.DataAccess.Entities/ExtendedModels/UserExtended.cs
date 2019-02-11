using SchoolMachine.DataAccess.Entities.Models.Security;
using System;
using System.Collections.Generic;

namespace SchoolMachine.DataAccess.Entities.ExtendedModels
{
    public class UserExtended
    {
        #region Concrete Properties

        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public bool IsActive { get; set; } = true;
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string UserName { get; set; }

        #endregion Concrete Properties

        #region Navigation Properties

        public IEnumerable<TeamUser> Teams { get; set; }

        public IEnumerable<UserRole> Roles { get; set; }

        #endregion Navigation Properties

        #region Constructors

        public UserExtended()
        {
        }

        public UserExtended(User user)
        {
            Id = user.Id;
            DateCreated = user.DateCreated;
            EmailAddress = user.EmailAddress;
            FirstName = user.FirstName;
            IsActive = user.IsActive;
            LastName = user.LastName;
            MiddleName = user.MiddleName;
            UserName = user.UserName;
        }

        #endregion Constructors
    }
}
