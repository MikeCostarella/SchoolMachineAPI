using System;

namespace SchoolMachine.API.Models.Base
{
    public interface IBaseServiceResponse
    {
        #region Properties

        Guid Id { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        #endregion Properties
    }
}
