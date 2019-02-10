using Microsoft.Extensions.Configuration;
using System.IO;

namespace SchoolMachine.Common.Configuration
{
    public static class Utilities
    {
        public static string SchoolMachoneDbConnection()
        {
            var builder = new ConfigurationBuilder();
            builder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("SchoolMachineNpgSql");
            return connectionString;
        }
    }
}
