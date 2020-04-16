namespace SchoolMachine.DataAccess.Entities.Authorization.Models.Identity.Configurations
{
    using System;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class IdentityUserTokenConfiguration : IEntityTypeConfiguration<IdentityUserToken<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<Guid>> entity)
        {
            entity.ToTable("user_token", "identity");
        }
    }
}