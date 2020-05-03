using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.DataAccess.Entities.Authorization.Models.Identity;
using SchoolMachine.DataAccess.Entities.SeedData.Model.Identity;
using System;

namespace SchoolMachine.UI.Telerik.AspNetCoreApp.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void DeleteAndRecreateDatabase(this IApplicationBuilder app, IConfiguration configuration)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<SchoolMachineContext>();
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                context.RebuildDbIfRequired(true);
                var identitySeeder = new IdentitySeeder(context, roleManager, userManager);
                var identityTask = identitySeeder.Seed();
                identityTask.Wait();
            }
        }
    }
}
