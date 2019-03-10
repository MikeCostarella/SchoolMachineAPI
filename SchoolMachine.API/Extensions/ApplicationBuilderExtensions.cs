using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolMachine.DataAccess.Entities;

namespace SchoolMachine.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void DeleteAndRecreateDatabase(this IApplicationBuilder app, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("AppSettings");
            var isRecreateDatabase = appSettingsSection["IsRecreateDatabase"];
            if (isRecreateDatabase.ToLower() == "true")
            {
                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<SchoolMachineContext>();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                }
            }
        }
    }
}