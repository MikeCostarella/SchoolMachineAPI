using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.Contracts;
using SchoolMachine.Logging.LoggerService;
using SchoolMachine.Repository;
using SchoolMachine.API.Helpers;
using System.Text;
using AutoMapper.Configuration;
using Microsoft.IdentityModel.Tokens;
using SchoolMachine.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Threading.Tasks;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

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
            //services.AddDbContext<RepositoryContext>
            //    (options => options.UseSqlServer(Utilities.SchoolMachoneDbConnection()));
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<RepositoryContext>()
                .BuildServiceProvider();
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
                        var userId = int.Parse(context.Principal.Identity.Name);
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
