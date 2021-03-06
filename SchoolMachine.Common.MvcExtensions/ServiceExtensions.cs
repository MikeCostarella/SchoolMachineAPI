﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.Contracts;
using SchoolMachine.Logging.LoggerService;
using SchoolMachine.Repository;
using System.Text;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolMachine.DbConnectionManagement;
using SchoolMachine.API.Settings;
using SchoolMachine.Common.Extensions;
using SchoolMachine.API.Configurations;
using SchoolMachine.API.Services;
using SchoolMachine.DataAccess.Entities.Authorization.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace SchoolMachine.Common.MvcExtensions
{
    /// <summary>
    /// Contains extension methods to configure services
    /// </summary>
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

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<SchoolMachineContext>()
                .AddDefaultTokenProviders();
        }

        public static void ConfigureAuthorization(this IServiceCollection services, PolicySettings policySettings)
        {
            services.AddAuthorization(options =>
            {
                foreach (var policySetting in policySettings.Policies)
                {
                    options.AddPolicy(policySetting.Name, policy =>
                    {
                        if (policySetting.Claims.Count() == 1)
                        {
                            var claim = policySetting.Claims.Single();
                            policy.RequireClaim(claim.ClaimType.GetDescription(), claim.ClaimValues);
                        }
                        else
                        {
                            policy.RequireAssertion(context =>
                            {
                                return context.User.Claims.Any(x => policySetting.Claims.Select(y => y.ClaimType.GetDescription()).Contains(x.Type));
                            });
                        }
                    });
                }
            });
        }

        public static void ConfigureAuthTokenService(this IServiceCollection services, IConfiguration config)
        {
            var appSettings = config.GetSection(typeof(AppSettings).Name).Get<AppSettings>();
            services.AddSingleton<IAuthTokenConfiguration>(new AuthTokenConfiguration(appSettings.AuthTokenExpirationMinutes, appSettings.AuthTokenIssuerSigningKey, appSettings.AuthTokenValidAudience, appSettings.AuthTokenValidIssuer));
            services.AddSingleton<IAuthTokenGeneratorService, AuthTokenGeneratorService>();
        }

        /// <summary>
        /// Configure CORS policy  (Cross-Origin Resource Sharing)
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());

                // More restrictive cors policy as example
                //options.AddPolicy("CorsPolicy",
                //    builder => builder.WithOrigins("http://www.something.com")
                //    .AllowAnyMethod()
                //    .WithHeaders("accept", "content-type")
                //    .AllowCredentials());

            });
        }

        /// <summary>
        /// Configure IIS Integration
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        /// <summary>
        /// Configure the logging service
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            // AddScoped - once per http request
            // AddTransient - once per call to logger service
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        /// <summary>
        /// Add the Repository context to the IOC container
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void ConfigureRepositoryContext(this IServiceCollection services, IConfiguration config)
        {
            var appSettingsSection = config.GetSection("AppSettings");
            var databaseProviderName = appSettingsSection["DatabaseProvider"];
            switch (databaseProviderName)
            {
                case "InMemory":
                    services.AddDbContext<SchoolMachineContext>
                        (options => options.UseInMemoryDatabase(databaseName: config.GetConnectionString("InMemoryDb")));
                    break;
                case "Npgsql":
                    services.AddEntityFrameworkNpgsql()
                        .AddDbContext<SchoolMachineContext>(options => options.UseNpgsql(config.GetConnectionString("NpgSql")))
                        .BuildServiceProvider();
                    break;
                case "Sqlite":
                    services.AddDbContext<SchoolMachineContext>
                        (options => options.UseSqlite(config.GetConnectionString("Sqlite")));
                    break;
                case "SqlServer":
                    services.AddDbContext<SchoolMachineContext>
                        (options => options.UseSqlServer(config.GetConnectionString("SqlServer")));
                    break;
                default:
                    services.AddDbContext<SchoolMachineContext>
                        (options => options.UseInMemoryDatabase(databaseName: config.GetConnectionString("InMemoryDb")));
                    break;
            }
        }

        /// <summary>
        /// Add the Repository context to the IOC container
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <param name="databaseProviderName"></param>
        public static void ConfigureRepositoryContext(this IServiceCollection services, IConfiguration config, string databaseProviderName)
        {
            switch (databaseProviderName)
            {
                case "InMemory":
                    services.AddDbContext<SchoolMachineContext>
                        (options => options.UseInMemoryDatabase(databaseName: config.GetConnectionString("InMemoryDb")));
                    break;
                case "Npgsql":
                    services.AddEntityFrameworkNpgsql()
                        .AddDbContext<SchoolMachineContext>(options => options.UseNpgsql(config.GetConnectionString("NpgSql")))
                        .BuildServiceProvider();
                    break;
                case "Sqlite":
                    services.AddDbContext<SchoolMachineContext>
                        (options => options.UseSqlite(config.GetConnectionString("Sqlite")));
                    break;
                case "SqlServer":
                    services.AddDbContext<SchoolMachineContext>
                        (options => options.UseSqlServer(config.GetConnectionString("SqlServer")));
                    break;
                default:
                    services.AddDbContext<SchoolMachineContext>
                        (options => options.UseInMemoryDatabase(databaseName: config.GetConnectionString("InMemoryDb")));
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

        /// <summary>
        /// Register the Swagger generator, defining the swagger document(s)
        /// </summary>
        /// <param name="services"></param>

        public static void ConfigureUserService(this IServiceCollection services, IConfiguration configuration)
        {
            // configure strongly typed settings objects
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services
                .AddAuthentication("custom")
                .AddJwtBearer("custom", options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = appSettings.AuthTokenValidAudience,
                        ValidIssuer = appSettings.AuthTokenValidIssuer
                    };
                });
        }
    }
}
