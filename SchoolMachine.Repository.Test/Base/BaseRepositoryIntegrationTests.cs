using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.DataAccess.Entities.Authorization.Models.Identity;
using SchoolMachine.DataAccess.Entities.SeedData;
using SchoolMachine.DataAccess.Entities.SeedData.Model.Identity;
using SchoolMachine.DbConnectionManagement;
using System;
using System.Linq;

namespace SchoolMachine.Repository.Test.Base
{
    public class BaseRepositoryIntegrationTests
    {
        #region Static Properties

        public static SchoolMachineContext SchoolMachineContext { get; set; }

        #endregion Static Properties

        #region Setup/Teardown

        public static void BaseTestClassSetup(TestContext context)
        {
            IConfiguration Configuration = new ConfigurationBuilder().Build();
            try
            {
                string[] args = new string[0];
                var webHostBuilder = WebHost
                    .CreateDefaultBuilder(args)
                    .ConfigureAppConfiguration(
                        (context, config) =>
                            KeyVaultConnectionManager.ConfigureSchoolMachineConfiguration(config)
                        )
                    .UseStartup<Startup>();
                var webHost = webHostBuilder.Build();
                var roleManager = webHost.Services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
                var userManager = webHost.Services.GetRequiredService<UserManager<ApplicationUser>>();
                var builder = new DbContextOptionsBuilder<SchoolMachineContext>();
                builder.UseInMemoryDatabase(databaseName: "SchoolMachine");
                var dbContextOptions = builder.Options;
                SchoolMachineContext = new SchoolMachineContext(dbContextOptions, Configuration);
                DataSeeder.Seed(SchoolMachineContext);
                var identitySeeder = new IdentitySeeder(SchoolMachineContext, roleManager, userManager);
                var identityTask = identitySeeder.Seed();
                identityTask.Wait();

                // Test Assertions

                Assert.IsTrue(SchoolMachineContext.Districts.Count() >= DataSeeder.DistrictSeeder.Objects.Count()
                    , string.Format("Database has {0} SchoolDistricts and Seeder has {1}", SchoolMachineContext.Districts.Count(), DataSeeder.DistrictSeeder.Objects.Count()));

                Assert.IsTrue(SchoolMachineContext.Schools.Count() >= DataSeeder.SchoolSeeder.Objects.Count()
                    , string.Format("Database has {0} Schools and Seeder has {1}", SchoolMachineContext.Schools.Count(), DataSeeder.SchoolSeeder.Objects.Count()));

                Assert.IsTrue(SchoolMachineContext.Students.Count() >= DataSeeder.StudentSeeder.Objects.Count()
                    , string.Format("Database has {0} Students and Seeder has {1}", SchoolMachineContext.Students.Count(), DataSeeder.StudentSeeder.Objects.Count()));

                Assert.IsTrue(SchoolMachineContext.DistrictSchools.Count() >= DataSeeder.DistrictSchools.Count()
                    , string.Format("Database has {0} SchoolDistrictSchools and Seeder has {1}", SchoolMachineContext.DistrictSchools.Count(), DataSeeder.DistrictSchools.Count()));

                Assert.IsTrue(SchoolMachineContext.SchoolStudents.Count() >= DataSeeder.SchoolStudents.Count()
                    , string.Format("Database has {0} SchoolStudents and Seeder has {1}", SchoolMachineContext.SchoolStudents.Count(), DataSeeder.SchoolStudents.Count()));
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("Unexpected exception occurred during test class intialization: {0}", ex));
            }
        }

        public static void BaseTestClassCleanup()
        {
            SchoolMachineContext = null;
        }

        #endregion Setup/Teardown
    }
}
