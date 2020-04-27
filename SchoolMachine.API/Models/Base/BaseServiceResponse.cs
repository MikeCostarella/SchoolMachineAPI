using System;

namespace SchoolMachine.API.Models.Base
{
    public class BaseServiceResponse : IBaseServiceResponse
    {
        #region Public Properties

        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsSuccessful { get; set; } = false;
        public string Message { get; set; }

        #endregion Public Properties
    }
}
