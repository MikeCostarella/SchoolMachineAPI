using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using SchoolMachine.API.Extensions;
using SchoolMachine.DbConnectionManagement;

namespace SchoolMachine.API
{
    public class Startup
    {
        #region Public Properties

        public IConfiguration Configuration { get; }

        #endregion Public Properties

        #region Constructors

        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            var directoryPath = hostingEnvironment.ContentRootPath;
            NLog.LogManager.LoadConfiguration(String.Concat(directoryPath, "/nlog.config"));
            Configuration = configuration;
        }

        #endregion Constructors

        #region Public Methods

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry();
            //services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.ConfigureLoggerService();
            services.ConfigureRepositoryContext(Configuration);
            services.ConfigureRepositoryWrapper();
            services.AddMvc(mvcOptions =>
            {
                mvcOptions.RespectBrowserAcceptHeader = true;
                // Return a 406 (Not Acceptable status code) if invalid media type negotiation is attempted
                mvcOptions.ReturnHttpNotAcceptable = true;
                mvcOptions.InputFormatters.Add(new XmlSerializerInputFormatter(mvcOptions));
                mvcOptions.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            }
            ).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddApiVersioning();
            services.ConfigureAutoMapper();
            services.ConfigureUserService(Configuration);
            services.ConfigureSwaggerGenerator();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var appSettings = Configuration.GetSection(typeof(AppSettings).Name).Get<AppSettings>();
            if (appSettings.IsRecreateDatabase)
            {
                app.DeleteAndRecreateDatabase(Configuration);
            }
            if (appSettings.UseHosts)
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            {
                builder
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowAnyMethod();
            });

            // will forward proxy headers to the current request. Will help during the Linux deployment
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });
            // will point on the index page in the Angular project
            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == 404
                    && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SchoolMachine API V1");
                c.RoutePrefix = string.Empty;
            });
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources");
            if (Directory.Exists(directoryPath))
            {
                app.UseStaticFiles();
                app.UseStaticFiles(new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(directoryPath),
                    RequestPath = new Microsoft.AspNetCore.Http.PathString("/Resources")
                });
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(options =>
            {
            options.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}/{id?}").RequireAuthorization();
            });
        }

        #endregion Public Methods
    }
}
