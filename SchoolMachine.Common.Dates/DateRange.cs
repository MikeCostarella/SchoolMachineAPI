using System;

namespace SchoolMachine.Common.Dates
{
    public class DateRange
    {
        #region Public Properties

        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }

        #endregion Public Properties

        #region Constructors

        public DateRange(DateTime? start, DateTime? end)
        {
            Start = start;
            End = end;
        }

        #endregion Constructors

        #region Operations

        public bool Includes(DateTime dateTime)
        {
            if (!Start.HasValue && !End.HasValue) return true;
            if (!Start.HasValue)
            {
                if (dateTime <= End) return true;
            }
            if (!End.HasValue)
            {
                if (dateTime >= Start) return true;
            }
            if (dateTime >= Start && dateTime <= End) return true;
            return false;
        }

        #endregion Operations
    }
}
