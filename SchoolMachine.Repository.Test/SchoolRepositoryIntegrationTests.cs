using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.DataAccess.Entities.SeedData;
using SchoolMachine.Repository.Entities;
using System.Linq;

namespace SchoolMachine.Repository.Test
{
    [TestClass]
    public class SchoolRepositoryIntegrationTests
    {
        public static SchoolMachineContext SchoolMachineContext { get; set; }

        #region Setup/Teardown

        [ClassInitialize]
        public static void TestClassSetup(TestContext context)
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
            SchoolMachineContext = new SchoolMachineContext(dbContextOptions);
            SchoolMachineContext.Database.Migrate();

            // Test Assertions
            Assert.IsTrue(SchoolMachineContext.Roles.Count() == DataSeeder.Roles.Count()
                , string.Format("Database has {0} Roles and Seeder has {1}", SchoolMachineContext.Roles.Count(), DataSeeder.Roles.Count()));
            Assert.IsTrue(SchoolMachineContext.Schools.Count() == DataSeeder.Schools.Count()
                , string.Format("Database has {0} Schools and Seeder has {1}", SchoolMachineContext.Schools.Count(), DataSeeder.Schools.Count()));
            Assert.IsTrue(SchoolMachineContext.Students.Count() == DataSeeder.Students.Count()
                , string.Format("Database has {0} Students and Seeder has {1}", SchoolMachineContext.Students.Count(), DataSeeder.Students.Count()));
            Assert.IsTrue(SchoolMachineContext.Users.Count() == DataSeeder.Users.Count()
                , string.Format("Database has {0} Users and Seeder has {1}", SchoolMachineContext.Users.Count(), DataSeeder.Users.Count()));
        }

        [ClassCleanup]
        public static void TestClassCleanup()
        {
            SchoolMachineContext = null;
        }

        #endregion Setup/Teardown

        #region Test Methods

        [TestMethod]
        public void GetAllSchools()
        {
            // Setup
            var schoolRepository = new SchoolRepository(SchoolMachineContext);
            // Test Logic
            var schools = schoolRepository.GetAllSchools();
            // Assertions
            Assert.IsTrue(schools.Count() == DataSeeder.Schools.Count()
                , string.Format("Database has {0} Schools and Seeder has {1}", schools.Count(), DataSeeder.Schools.Count()));
        }

        [TestMethod]
        public void GetSchoolById()
        {
            // Setup
            var schoolRepository = new SchoolRepository(SchoolMachineContext);
            // Test Logic
            var school = schoolRepository.GetSchoolById(DataSeeder.Schools[0].Id);
            // Assertions
            Assert.IsNotNull(school, string.Format("Did not find school with Id: {0}", DataSeeder.Schools[0].Id));
        }

        // ToDo: getting the school details from repository needs some more work yet
        [TestMethod]
        public void GetSchoolWithDetails()
        {
            // Setup
            var schoolRepository = new SchoolRepository(SchoolMachineContext);
            // Test Logic
            var school = schoolRepository.GetSchoolWithDetails(DataSeeder.Schools[0].Id);
            // Assertions
            Assert.IsNotNull(school, string.Format("Did not find school with Id: {0}", DataSeeder.Schools[0].Id));
        }

        #endregion Test Methods
    }
}