namespace SchoolMachine.API.Configurations
{
    using SchoolMachine.Common.Extensions;
    using System;

    public class AuthTokenConfiguration : IAuthTokenConfiguration
    {
        public AuthTokenConfiguration(int expirationMinutes, string issuerSigningKey, string validAudience, string validIssuer)
        {
            this.ExpirationMinutes = expirationMinutes >= 0 ? expirationMinutes : throw new ArgumentNullException(nameof(expirationMinutes));
            this.IssuerSigningKey = issuerSigningKey.HasValue() ? issuerSigningKey : throw new ArgumentNullException(nameof(issuerSigningKey));
            this.ValidAudience = validAudience.HasValue() ? validAudience : throw new ArgumentNullException(nameof(validAudience));
            this.ValidIssuer = validIssuer.HasValue() ? validIssuer : throw new ArgumentNullException(nameof(validIssuer));
        }

        public int ExpirationMinutes { get; }

        public string IssuerSigningKey { get; }

        public string ValidAudience { get; }

        public string ValidIssuer { get; }
    }
}