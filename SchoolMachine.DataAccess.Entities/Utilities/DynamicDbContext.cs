using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolMachine.DataAccess.Entities.Authorization.Models.Identity;
using System;

namespace SchoolMachine.DataAccess.Entities.Utilities
{
    public class DynamicDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        #region Constructors

        public DynamicDbContext(DbContextOptions options) : base(options)
        {
        }

        #endregion Constructors

        #region Initialization

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolMachineContext).Assembly);
        }

        #endregion Initialization
    }
}
