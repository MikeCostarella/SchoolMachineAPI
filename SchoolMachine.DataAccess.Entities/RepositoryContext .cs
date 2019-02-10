using Microsoft.EntityFrameworkCore;
using SchoolMachine.Common.Configuration;
using SchoolMachine.DataAccess.Entities.Models;
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

        #region DbSet Methods

        public DbSet<School> Schools { get; set; }

        public DbSet<SchoolStudent> SchoolStudents { get; set; }

        public DbSet<Student> Students { get; set; }

        #endregion DbSet Methods

        #region Data Seeding

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>().HasData(SeedDataFactory.Schools[0]);
            modelBuilder.Entity<School>().HasData(SeedDataFactory.Schools[1]);
            modelBuilder.Entity<Student>().HasData(SeedDataFactory.Students[0]);
            modelBuilder.Entity<Student>().HasData(SeedDataFactory.Students[1]);
            modelBuilder.Entity<Student>().HasData(SeedDataFactory.Students[2]);
            modelBuilder.Entity<Student>().HasData(SeedDataFactory.Students[3]);
        }

        #endregion Data Seeding
    }
}