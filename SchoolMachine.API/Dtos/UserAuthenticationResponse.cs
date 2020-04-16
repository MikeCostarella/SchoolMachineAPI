using System;
using System.Collections.Generic;

namespace SchoolMachine.API.Dtos
{
    public class UserAuthenticationResponse
    {
        public UserAuthenticationResponse(){ }

        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsSuccessful { get; set; } = false;
        public string Message { get; set; } = string.Empty;

        public List<string> Permissions { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
    }
}
