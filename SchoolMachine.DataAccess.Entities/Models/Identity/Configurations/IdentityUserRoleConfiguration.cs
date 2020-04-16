namespace SchoolMachine.DataAccess.Entities.Authorization.Models.Identity.Configurations
{
    using System;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> entity)
        {
            entity.ToTable("user_role", "identity");
        }
    }
}