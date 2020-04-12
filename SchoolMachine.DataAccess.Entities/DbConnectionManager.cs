using Microsoft.Extensions.Configuration;

namespace SchoolMachine.DataAccess.Entities
{
    public class DbConnectionManager : IDbConnectionManager
    {
        private const string DEFAULT_DB_PROVIDER_CONNECTION = "SchoolMachine";

        public static string ConnectionString(IConfiguration config)
        {
            var appSettingsSection = config.GetSection("AppSettings");
            if (appSettingsSection["DatabaseProvider"] == null)
            {
                return DEFAULT_DB_PROVIDER_CONNECTION;
            }
            var connectionString = DEFAULT_DB_PROVIDER_CONNECTION;
            var connectionName = DatabasePlatformName(config);
            switch(connectionName)
            {
                case "InMemory":
                    connectionString = config.GetConnectionString("InMemoryDb");
                    break;
                case "Npgsql":
                    connectionString = config.GetConnectionString("Npgsql");
                    break;
                case "Sqlite":
                    connectionString = config.GetConnectionString("Sqlite");
                    break;
                case "SqlServer":
                    connectionString = config.GetConnectionString("SqlServer");
                    break;
                default:
                    connectionString = DEFAULT_DB_PROVIDER_CONNECTION;
                    break;
            }
            return connectionString;
        }

        public static string DatabasePlatformName(IConfiguration config)
        {
            return config.GetSection("AppSettings")["DatabaseProvider"] ?? "InMemory";
        }
    }
}
