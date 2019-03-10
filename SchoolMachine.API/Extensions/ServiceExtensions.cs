using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.Contracts;
using SchoolMachine.Logging.LoggerService;
using SchoolMachine.Repository;
using SchoolMachine.API.Helpers;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SchoolMachine.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Threading.Tasks;
using System;
using System.Reflection;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace SchoolMachine.API.Extensions
{
    /// <summary>
    /// Contains extension methods to configure services
    /// </summary>
    public static class ServiceExtensions
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            //ToDo: Investigate why this reference is undefined.
            //services.AddAutoMapper();

            // Workaround - for now
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
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
                        (options => options.UseInMemoryDatabase(databaseName: config.GetConnectionString("SchoolMachineInMemoryDb")));
                    break;
                case "Npgsql":
                    services.AddEntityFrameworkNpgsql()
                        .AddDbContext<SchoolMachineContext>(options => options.UseNpgsql(config.GetConnectionString("SchoolMachineNpgSql")))
                        .BuildServiceProvider();
                    break;
                case "Sqlite":
                    services.AddDbContext<SchoolMachineContext>
                        (options => options.UseSqlite("Data Source=SchoolMachine.db"));
                    break;
                case "SqlServer":
                    services.AddDbContext<SchoolMachineContext>
                        (options => options.UseSqlServer(config.GetConnectionString("SchoolMachineSqlServer")));
                    break;
                default:
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
        public static void ConfigureSwaggerGenerator(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info {
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact
                    {
                        Email = "costarellamike@gmail.com",
                        Name = "Mike Costarella",
                        Url = "https://www.linkedin.com/in/mikecostarella/"
                    },
                    Description = "Provides Web API services to support SchoolMachine functionality.",
                    Title = "SchoolMachine API",
                    Version = "v1"
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

        }

        public static void ConfigureUserService(this IServiceCollection services, IConfiguration configuration)
        {

            // configure strongly typed settings objects
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var userId = Guid.Parse(context.Principal.Identity.Name);
                        var user = userService.GetById(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();

        }
    }
}
