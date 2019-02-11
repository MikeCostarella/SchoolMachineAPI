using SchoolMachine.DataAccess.Entities.Models.Security;
using System;
using System.Collections.Generic;

namespace SchoolMachine.DataAccess.Entities.ExtendedModels
{
    public class TeamExtended
    {
        #region Concrete Properties

        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
        public string Name { get; set; }

        #endregion Concrete Properties

        #region Navigation Properties

        public IEnumerable<TeamRole> Roles { get; set; }

        public IEnumerable<TeamUser> Users { get; set; }

        #endregion Navigation Properties

        #region Constructors

        public TeamExtended()
        {
        }

        public TeamExtended(Team team)
        {
            Id = team.Id;
            DateCreated = team.DateCreated;
            DateModified = team.DateModified;
            Description = team.Description;
            IsActive = team.IsActive;
            Name = team.Name;
        }

        #endregion Constructors
    }
}
