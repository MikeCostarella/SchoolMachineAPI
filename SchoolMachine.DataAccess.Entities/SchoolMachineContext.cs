using Microsoft.EntityFrameworkCore;
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
                // ToDo: place this db connection into appsettings.json as a secret
                optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=SchoolMachine;User Id=postgres;Password=password;");
            }
        }

        #endregion Configuration

        #region DbSets

        #region SchoolData Schema

        public DbSet<District> Districts { get; set; }
        public DbSet<DistrictSchool> DistrictSchools { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<SchoolStudent> SchoolStudents { get; set; }
        public DbSet<Student> Students { get; set; }

        #endregion SchoolDate Schema

        #region Security Schema

        public DbSet<Role> Roles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamRole> TeamRoles { get; set; }
        public DbSet<TeamUser> TeamUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    
        #endregion Security Schema

        #endregion DbSets

        #region Data Seeding
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var role in DataSeeder.Roles) { modelBuilder.Entity<Role>().HasData(role); }
            foreach (var user in DataSeeder.Users) { modelBuilder.Entity<User>().HasData(user); }
            foreach (var schoolDistrict in DataSeeder.SchoolDistricts) { modelBuilder.Entity<District>().HasData(schoolDistrict); }
            foreach (var school in DataSeeder.Schools) { modelBuilder.Entity<School>().HasData(school); }
            foreach (var school in DataSeeder.Students) { modelBuilder.Entity<Student>().HasData(school); }
            foreach (var schoolDistrictSchool in DataSeeder.SchoolDistrictSchools) { modelBuilder.Entity<DistrictSchool>().HasData(schoolDistrictSchool); }
            foreach (var schoolStudent in DataSeeder.SchoolStudents) { modelBuilder.Entity<SchoolStudent>().HasData(schoolStudent); }
        }

        #endregion Data Seeding
    }
}