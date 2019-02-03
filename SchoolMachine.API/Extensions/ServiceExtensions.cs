using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.Contracts;
using SchoolMachine.Logging.LoggerService;
using SchoolMachine.Repository;

namespace SchoolMachine.API.Extensions
{
    /// <summary>
    /// Contains extension methods to configure services
    /// </summary>
    public static class ServiceExtensions
    {
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
            // ToDo: refactor connnection to appsettings.json
            var connection = @"Server=(localdb)\mssqllocaldb;Database=SchoolMachine;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<RepositoryContext>
                (options => options.UseSqlServer(connection));
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
        public static void ConfigureSwaggerGenerator(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "SchoolMachine API", Version = "v1" });
            });
        }
    }
}
