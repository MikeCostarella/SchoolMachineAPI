using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolMachine.API.Extensions;
using System;
using System.IO;

namespace SchoolMachine.Testing.API
{
    public class TestStartup
    {
        public TestStartup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            var directoryPath = hostingEnvironment.ContentRootPath;
            NLog.LogManager.LoadConfiguration(String.Concat(directoryPath, "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCors();

            services.ConfigureIISIntegration();

            services.ConfigureLoggerService();

            services.ConfigureRepositoryContext(Configuration);

            services.ConfigureRepositoryWrapper();

            TestInitializer.RegisterMockRepositories(services);

            services.AddMvcCore(mvcOptions =>
            {
                mvcOptions.RespectBrowserAcceptHeader = true;

                // Return a 406 (Not Acceptable status code) if invalid media type negotiation is attempted
                mvcOptions.ReturnHttpNotAcceptable = true;

                mvcOptions.InputFormatters.Add(new XmlSerializerInputFormatter(mvcOptions));
                mvcOptions.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            }
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            //app.UseCors("CorsPolicy");

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

            //app.UseStaticFiles();

            //app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
