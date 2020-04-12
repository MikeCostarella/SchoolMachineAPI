using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolMachine.DataAccess.Entities;

namespace SchoolMachine.DbGeneratorApp
{
    public static class ApplicationBuilderExtensions
    {
        public static void DeleteAndRecreateDatabase(this IApplicationBuilder app, IConfiguration configuration)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<SchoolMachineContext>();
                context.RebuildDbIfRequired(true);
            }
        }
    }
}
