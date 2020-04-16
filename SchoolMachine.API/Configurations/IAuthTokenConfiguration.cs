namespace SchoolMachine.API.Configurations
{
    public interface IAuthTokenConfiguration
    {
        int ExpirationMinutes { get; }

        string IssuerSigningKey { get; }

        string ValidAudience { get; }

        string ValidIssuer { get; }
    }
}