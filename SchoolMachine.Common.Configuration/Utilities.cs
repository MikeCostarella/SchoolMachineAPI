using Microsoft.Extensions.Configuration;
using System.IO;

namespace SchoolMachine.Common.Configuration
{
    public static class Utilities
    {
        public static string SchoolMachoneDbConnection()
        {
            var builder = new ConfigurationBuilder();
            var directoryPath = Directory.GetCurrentDirectory();
            builder
                .SetBasePath(directoryPath)
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("SchoolMachineNpgSql");
            return connectionString;
        }
    }
}
