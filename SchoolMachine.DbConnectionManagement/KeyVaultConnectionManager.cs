using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using System;
using System.IO;

namespace SchoolMachine.DbConnectionManagement
{
    public class KeyVaultConnectionManager
    {
        public static void ConfigureSchoolMachineConfiguration(IConfigurationBuilder configurationBuilder)
        {
            SchoolMachineConfigBuilder(configurationBuilder);
        }

        public static IConfiguration CreateApplicationConfiguration()
        {
            var builder = new ConfigurationBuilder();
            SchoolMachineConfigBuilder(builder);
            return builder.Build();
        }

        private static void SchoolMachineConfigBuilder(IConfigurationBuilder builder)
        {
            //debug is default
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            env = String.IsNullOrEmpty(env) ? "debug" : env.Trim().ToLower();
            var currentDirectory = Directory.GetCurrentDirectory();
            builder
                .SetBasePath(currentDirectory)
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appSettings.{ env }.json", optional: false);
            if (env == "debug")
            {
                builder.AddUserSecrets<ConnectionStrings>();
            }
            else
            {
                // dev, test, production
                AddKeyVaultValues(builder);
            }
            builder.AddEnvironmentVariables();
        }

        private static void AddKeyVaultValues(IConfigurationBuilder configurationBuilder)
        {
            var iConfigurationBuilder = configurationBuilder.Build();
            var appSettingsSection = iConfigurationBuilder.GetSection(typeof(AppSettings).Name).Get<AppSettings>();
            var keyVaultPath = $"https://{ appSettingsSection.KeyVaultName }.vault.azure.net/";
            if (appSettingsSection.UseAzureKeyVault)
            {
                var azureServiceTokenProvider = new AzureServiceTokenProvider();
                var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
                configurationBuilder.AddAzureKeyVault(
                    $"{ keyVaultPath }",
                    keyVaultClient,
                    new DefaultKeyVaultSecretManager()
                );
            }
        }
    }
}
