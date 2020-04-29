using System.Collections.Generic;

namespace SchoolMachine.DbConnectionManagement
{
    public class AppSettings
    {
        public int AuthTokenExpirationMinutes { get; set; }
        public string AuthTokenIssuerSigningKey { get; set; }
        public string AuthTokenValidAudience { get; set; }
        public string AuthTokenValidIssuer { get; set; }
        public string AzureADApplicationId { get; set; }
        public string DatabaseProvider { get; set; }
        public string EnterpriseLoggingPath { get; set; }
        public int ExternalSystemTimeOutMinutes { get; set; } = 5;
        public int ExternalSystemTimeOutSeconds { get; set; } = 0;
        public bool IsRecreateDatabase { get; set; }
        public string KeyVaultName { get; set; }
        public Dictionary<string, MessagingConnectionSettings> MessagingConnectionSettings { get; set; }
        public string[] PossibleDatabaseProviders { get; set; }
        public string RepairStatusUpdateBaseUrl { get; set; }
        public string Secret { get; set; }
        public string SendGridApiKey { get; set; }
        public string ServiceBusConnectionString { get; set; }
        public bool UseAzureMessageQueue { get; set; }
        public bool UseAzureKeyVault { get; set; }
        public bool UseHosts { get; set; }
    }
}
