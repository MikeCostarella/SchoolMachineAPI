namespace SchoolMachine.DataAccess.Entities.Authorization.Models.Identity.Configurations
{
    using System;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> entity)
        {
            entity.ToTable("role", "identity");
        }
    }
}