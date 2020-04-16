namespace SchoolMachine.API.Services
{
    using System.Collections.Generic;
    using System.Security.Claims;

    public interface IAuthTokenGeneratorService
    {
        string GenerateToken(IEnumerable<Claim> claims);
    }
}