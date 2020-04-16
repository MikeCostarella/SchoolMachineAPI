using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SchoolMachine.DataAccess.Entities.Extensions.Utilities
{
    public static class DbContextOptionsBuilderExtensions
    {
        public static void SetDatabaseConnection(this DbContextOptionsBuilder dbContextOptionsBuilder, IConfiguration config)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                var connectionString = DbConnectionManager.ConnectionString(config);
                switch (DbConnectionManager.DatabasePlatformName(config))
                {
                    case "InMemory":
                        dbContextOptionsBuilder.UseInMemoryDatabase(databaseName: connectionString);
                        break;
                    case "Npgsql":
                        dbContextOptionsBuilder.UseNpgsql(connectionString);
                        break;
                    case "Sqlite":
                        dbContextOptionsBuilder.UseSqlite(connectionString);
                        break;
                    case "SqlServer":
                        dbContextOptionsBuilder.UseSqlServer(connectionString);
                        break;
                    default:
                        dbContextOptionsBuilder.UseInMemoryDatabase(databaseName: connectionString);
                        break;
                }
            }
        }
    }
}
