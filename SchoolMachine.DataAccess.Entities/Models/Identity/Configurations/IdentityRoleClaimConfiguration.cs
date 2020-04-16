namespace SchoolMachine.DataAccess.Entities.Authorization.Models.Identity.Configurations
{
    using System;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class IdentityRoleClaimConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRoleClaim<Guid>> entity)
        {
            entity.ToTable("role_claim", "identity");
        }
    }
}