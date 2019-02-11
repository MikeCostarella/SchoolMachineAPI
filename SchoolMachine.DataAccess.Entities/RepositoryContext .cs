using Microsoft.EntityFrameworkCore;
using SchoolMachine.Common.Configuration;
using SchoolMachine.DataAccess.Entities.Models.Security;
using SchoolMachine.DataAccess.Entities.SchoolData.Models;
using SchoolMachine.DataAccess.Entities.SeedData;
using System;

namespace SchoolMachine.DataAccess.Entities
{
    public class RepositoryContext : DbContext
    {
        #region Constructors

        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        #endregion Constructors

        #region Configuration

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Utilities.SchoolMachoneDbConnection());
        }

        #endregion Configuration

        #region DbSets

        #region SchoolData Schema

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
            modelBuilder.Entity<Role>().HasData(DataSeeder.Roles[0]);

            modelBuilder.Entity<User>().HasData(DataSeeder.Users[0]);

            modelBuilder.Entity<School>().HasData(DataSeeder.Schools[0]);
            modelBuilder.Entity<School>().HasData(DataSeeder.Schools[1]);

            modelBuilder.Entity<Student>().HasData(DataSeeder.Students[0]);
            modelBuilder.Entity<Student>().HasData(DataSeeder.Students[1]);
            modelBuilder.Entity<Student>().HasData(DataSeeder.Students[2]);
            modelBuilder.Entity<Student>().HasData(DataSeeder.Students[3]);
            modelBuilder.Entity<Student>().HasData(DataSeeder.Students[4]);
        }

        #endregion Data Seeding
    }
}