using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolMachine.API.Extensions;
using SchoolMachine.DataAccess.Entities;

namespace SchoolMachine.API
{
    public class Startup
    {
        #region Public Properties

        public IConfiguration Configuration { get; }

        #endregion Public Properties

        #region Constructors

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
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
            services.AddDbContext<SchoolMachineContext>(options => options.UseInMemoryDatabase(databaseName: "SchoolMachine"));
            services.ConfigureCors();
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
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.ConfigureAutoMapper();
            services.ConfigureUserService(Configuration);
            services.ConfigureSwaggerGenerator();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.DeleteAndRecreateDatabase();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("CorsPolicy");
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
            app.UseMvc();
        }

        #endregion Public Methods
    }
}
