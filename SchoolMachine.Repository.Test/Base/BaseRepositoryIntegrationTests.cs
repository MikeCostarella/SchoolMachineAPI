using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.DataAccess.Entities.SeedData;
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
            try
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
                var config = KeyVaultConnectionManager.CreateApplicationConfiguration();
                SchoolMachineContext = new SchoolMachineContext(dbContextOptions, config);
                SchoolMachineContext.Database.Migrate();

                // Test Assertions
                Assert.IsTrue(SchoolMachineContext.Roles.Count() >= DataSeeder.RoleSeeder.Objects.Count()
                    , string.Format("Database has {0} Roles and Seeder has {1}", SchoolMachineContext.Roles.Count(), DataSeeder.RoleSeeder.Objects.Count()));

                Assert.IsTrue(SchoolMachineContext.Districts.Count() >= DataSeeder.DistrictSeeder.Objects.Count()
                    , string.Format("Database has {0} SchoolDistricts and Seeder has {1}", SchoolMachineContext.Districts.Count(), DataSeeder.DistrictSeeder.Objects.Count()));

                Assert.IsTrue(SchoolMachineContext.Schools.Count() >= DataSeeder.SchoolSeeder.Objects.Count()
                    , string.Format("Database has {0} Schools and Seeder has {1}", SchoolMachineContext.Schools.Count(), DataSeeder.SchoolSeeder.Objects.Count()));

                Assert.IsTrue(SchoolMachineContext.Students.Count() >= DataSeeder.StudentSeeder.Objects.Count()
                    , string.Format("Database has {0} Students and Seeder has {1}", SchoolMachineContext.Students.Count(), DataSeeder.StudentSeeder.Objects.Count()));

                Assert.IsTrue(SchoolMachineContext.Users.Count() >= DataSeeder.UserSeeder.Objects.Count()
                    , string.Format("Database has {0} Users and Seeder has {1}", SchoolMachineContext.Users.Count(), DataSeeder.UserSeeder.Objects.Count()));

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
