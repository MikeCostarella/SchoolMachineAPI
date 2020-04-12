using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolMachine.DataAccess.Entities;

namespace SchoolMachine.DbGeneratorApp
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryContext(this IServiceCollection services, IConfiguration config)
        {
            var databaseConnectionString = DbConnectionManager.ConnectionString(config);
            switch (DbConnectionManager.DatabasePlatformName(config))
            {
                case "InMemory":
                    services.AddDbContext<SchoolMachineContext>
                        (options => options.UseInMemoryDatabase(databaseName: databaseConnectionString));
                    break;
                case "Npgsql":
                    services
                        .AddEntityFrameworkNpgsql()
                        .AddDbContext<SchoolMachineContext>(options => options.UseNpgsql(databaseConnectionString));
                    break;
                case "Sqlite":
                    services.AddDbContext<SchoolMachineContext>
                        (options => options.UseSqlite(databaseConnectionString));
                    break;
                case "SqlServer":
                    services.AddDbContext<SchoolMachineContext>
                        (options => options.UseSqlServer(databaseConnectionString));
                    break;
                default:
                    services.AddDbContext<SchoolMachineContext>
                        (options => options.UseInMemoryDatabase(databaseName: databaseConnectionString));
                    break;
            }
        }
    }
}
