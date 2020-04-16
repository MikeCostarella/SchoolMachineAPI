namespace SchoolMachine.DataAccess.Entities.Authorization.Models.Identity.Configurations
{
    using System;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class IdentityUserClaimConfiguration : IEntityTypeConfiguration<IdentityUserClaim<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<Guid>> entity)
        {
            entity.ToTable("user_claim", "identity");
        }
    }
}