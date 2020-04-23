using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolMachine.Common.MvcExtensions;

namespace SchoolMachine.Repository.Test.Base
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
            services.ConfigureRepositoryContext(Configuration, "InMemory");
            services.AddIdentityServiceFramework();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifeTime)
        {
            app.DeleteAndRecreateDatabase(true);
            lifeTime.StopApplication();
        }

        #endregion Public Methods
    }
}
