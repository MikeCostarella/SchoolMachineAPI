using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolMachine.Contracts;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.DataAccess.Entities.Authorization.Models.Identity;
using SchoolMachine.Repository;
using System;

namespace SchoolMachine.UI.Telerik.AspNetCoreApp.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddIdentityServiceFramework(this IServiceCollection services)
        {
            services
                .AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<SchoolMachineContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                //Password Settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            });
        }

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

        /// <summary>
        /// Add the Repository Wrapper to the IOC container
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
