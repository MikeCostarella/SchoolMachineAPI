using Microsoft.EntityFrameworkCore;
using SchoolMachine.DataAccess.Entities.Models.Geolocation;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using SchoolMachine.DataAccess.Entities.Models.Security;
using SchoolMachine.DataAccess.Entities.SeedData;

namespace SchoolMachine.DataAccess.Entities
{
    public class SchoolMachineContext : DbContext
    {
        #region Constructors

        public SchoolMachineContext(DbContextOptions options)
            : base(options)
        {
        }

        #endregion Constructors

        #region Configuration

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
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
        public DbSet<Student> Students { get; set; }

        #endregion SchoolDate Schema

        #region Security Schema

        public DbSet<Role> Roles { get; set; }
        public DbSet<Group> Teams { get; set; }
        public DbSet<GroupRole> TeamRoles { get; set; }
        public DbSet<GroupUser> TeamUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    
        #endregion Security Schema

        #endregion DbSets

        #region Data Seeding
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var country in DataSeeder.CountrySeeder.Objects) { modelBuilder.Entity<Country>().HasData(country); }
            foreach (var state in DataSeeder.StateSeeder.Objects) { modelBuilder.Entity<State>().HasData(state); }
            foreach (var location in DataSeeder.Locations) { modelBuilder.Entity<Location>().HasData(location); }
            foreach (var group in DataSeeder.GroupSeeder.Objects) { modelBuilder.Entity<Group>().HasData(group); }
            foreach (var role in DataSeeder.RoleSeeder.Objects) { modelBuilder.Entity<Role>().HasData(role); }
            foreach (var user in DataSeeder.UserSeeder.Objects) { modelBuilder.Entity<User>().HasData(user); }
            foreach (var district in DataSeeder.DistrictSeeder.Objects) { modelBuilder.Entity<District>().HasData(district); }
            foreach (var school in DataSeeder.SchoolSeeder.Objects) { modelBuilder.Entity<School>().HasData(school); }
            foreach (var school in DataSeeder.StudentSeeder.Objects) { modelBuilder.Entity<Student>().HasData(school); }
            foreach (var userRole in DataSeeder.UserRoles) { modelBuilder.Entity<UserRole>().HasData(userRole); }
            foreach (var groupRole in DataSeeder.GroupRoles) { modelBuilder.Entity<GroupRole>().HasData(groupRole); }
            foreach (var districtSchool in DataSeeder.DistrictSchools) { modelBuilder.Entity<DistrictSchool>().HasData(districtSchool); }
            foreach (var schoolStudent in DataSeeder.SchoolStudents) { modelBuilder.Entity<SchoolStudent>().HasData(schoolStudent); }
        }

        #endregion Data Seeding
    }
}