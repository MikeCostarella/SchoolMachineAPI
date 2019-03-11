using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolMachine.DataAccess.Entities;
using System;

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
                    try
                    {
                        context.Database.EnsureDeleted();
                    }
                    catch(Exception ex)
                    {
                        throw;
                    }
                    context.Database.EnsureCreated();
                }
            }
        }
    }
}