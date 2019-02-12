using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolMachine.DataAccess.Entities;
using System.Linq;

namespace SchoolMachine.Repository.Test
{
    [TestClass]
    public class SchoolRepositoryIntegrationTests
    {
        [TestMethod]
        public void GetAllSchools()
        {
            // Setup
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddEntityFrameworkNpgsql()
                .AddDbContext<SchoolMachineContext>()
                .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<SchoolMachineContext>();
            // ToDo: factor this to somewhere less visible
            builder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=SchoolMachine;User Id=postgres;Password=password;");
            var dbContextOptions = builder.Options;
            var dbContext = new SchoolMachineContext(dbContextOptions);
            dbContext.Database.Migrate();

            // Test Assertions
            Assert.IsTrue(dbContext.Roles.Count() > 0);
        }
    }
}
