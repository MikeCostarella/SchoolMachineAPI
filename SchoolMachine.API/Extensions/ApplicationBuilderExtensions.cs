using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SchoolMachine.DataAccess.Entities;

namespace SchoolMachine.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void DeleteAndRecreateDatabase(this IApplicationBuilder app)
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