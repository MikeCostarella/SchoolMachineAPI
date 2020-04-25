using SchoolMachine.DataAccess.Entities;
using System;

namespace SchoolMachine.DataAccess.Tools
{
    public class SchoolMachineDbContextCleaner
    {
        #region Member Variables

        private SchoolMachineContext schoolMachineContext;

        #endregion Member Variables

        #region Constructors

        public SchoolMachineDbContextCleaner(SchoolMachineContext schoolMachineContext)
        {
            this.schoolMachineContext = schoolMachineContext;
        }

        #endregion Constructors

        #region Actions

        public bool CleanOperationalTables()
        {
            try
            {
                schoolMachineContext.UserLogins.RemoveRange(schoolMachineContext.UserLogins);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion Actions
    }
}
