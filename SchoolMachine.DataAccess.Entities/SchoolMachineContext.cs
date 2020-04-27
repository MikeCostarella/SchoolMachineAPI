using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolMachine.Common.Global;
using SchoolMachine.DataAccess.Entities.Extensions.Utilities;
using SchoolMachine.DataAccess.Entities.Models.Geolocation;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using SchoolMachine.DataAccess.Entities.SeedData;
using SchoolMachine.DataAccess.Entities.Utilities;

namespace SchoolMachine.DataAccess.Entities
{
    public class SchoolMachineContext : DynamicDbContext
    {
        #region Properties

        public IConfiguration Config { get; }

        #endregion Properties

        #region Constructors

        public SchoolMachineContext(DbContextOptions options, IConfiguration config)
            : base(options)
        {
            Config = config;
        }

        #endregion Constructors

        #region Configuration

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!TestIndicator.IsTestMode)
            {
                dbContextOptionsBuilder.SetDatabaseConnection(Config);
                if (!dbContextOptionsBuilder.IsConfigured)
                {
                }
            }
        }
        public void RebuildDbIfRequired(bool force = false)
        {
            var appSettingsSection = Config.GetSection("AppSettings");
            var isRecreateDatabase = (appSettingsSection["IsRecreateDatabase"] != null) ? appSettingsSection["IsRecreateDatabase"] : "true";
            if (force || isRecreateDatabase.ToLower().Equals("true"))
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        #endregion Configuration

        #region DbSets

        #region Geolocation Schema

        public DbSet<Country> Countries { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<State> States { get; set; }

        #endregion Geolocation Schema

        #region SchoolData Schema

        public DbSet<District> Districts { get; set; }
        public DbSet<DistrictSchool> DistrictSchools { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<SchoolStudent> SchoolStudents { get; set; }
        public DbSet<StudentDistrictRegistration> StudentDistrictRegistration { get; set; }
        public DbSet<Student> Students { get; set; }

        #endregion SchoolDate Schema

        #endregion DbSets

        #region Data Seeding
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             base.OnModelCreating(modelBuilder);
            foreach (var country in DataSeeder.CountrySeeder.Objects) { modelBuilder.Entity<Country>().HasData(country); }
            foreach (var state in DataSeeder.StateSeeder.Objects) { modelBuilder.Entity<State>().HasData(state); }
            foreach (var location in DataSeeder.Locations) { modelBuilder.Entity<Location>().HasData(location); }
            foreach (var district in DataSeeder.DistrictSeeder.Objects) { modelBuilder.Entity<District>().HasData(district); }
            foreach (var school in DataSeeder.SchoolSeeder.Objects) { modelBuilder.Entity<School>().HasData(school); }
            foreach (var school in DataSeeder.StudentSeeder.Objects) { modelBuilder.Entity<Student>().HasData(school); }
            foreach (var districtSchool in DataSeeder.DistrictSchools) { modelBuilder.Entity<DistrictSchool>().HasData(districtSchool); }
            foreach (var schoolStudent in DataSeeder.SchoolStudents) { modelBuilder.Entity<SchoolStudent>().HasData(schoolStudent); }
        }

        #endregion Data Seeding
    }
}