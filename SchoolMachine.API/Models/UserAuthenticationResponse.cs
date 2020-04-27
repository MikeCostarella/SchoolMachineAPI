using SchoolMachine.API.Models.Base;
using System;
using System.Collections.Generic;

namespace SchoolMachine.API.Models
{
    public class UserAuthenticationResponse : BaseServiceResponse
    {
        #region Constructors

        public UserAuthenticationResponse(){ }

        #endregion Constructors

        #region Public Properties

        public List<string> Permissions { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }

        #endregion Public Properties
    }
}
