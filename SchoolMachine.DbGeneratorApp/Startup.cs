﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SchoolMachine.DbGeneratorApp
{
    public class Startup
    {
        #region Public Properties

        public IConfiguration Configuration { get; }

        #endregion Public Properties

        #region Constructors

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion Constructors

        #region Public Methods

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureRepositoryContext(Configuration);
            services.AddIdentityServiceFramework();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifeTime)
        {
            app.DeleteAndRecreateDatabase(Configuration);
            lifeTime.StopApplication();
        }

        #endregion Public Methods
    }
}
