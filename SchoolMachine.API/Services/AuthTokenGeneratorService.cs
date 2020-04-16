namespace SchoolMachine.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    using Microsoft.IdentityModel.Tokens;

    using Configurations;

    public class AuthTokenGeneratorService : IAuthTokenGeneratorService
    {
        private readonly IAuthTokenConfiguration configuration;

        public AuthTokenGeneratorService(IAuthTokenConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration.IssuerSigningKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                this.configuration.ValidIssuer,
                this.configuration.ValidAudience,
                claims,
                DateTime.Now,
                DateTime.Now.AddMinutes(this.configuration.ExpirationMinutes),
                credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}