namespace SchoolMachine.DataAccess.Entities.Authorization.Models.Identity.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> entity)
        {
            entity.ToTable("user", "identity");

            //entity.Property(e => e.ServiceCenterId).IsRequired();

            //entity.HasOne(e => e.ServiceCenter)
            //    .WithMany(e => e.ApplicationUsers)
            //    .HasForeignKey(k => k.ServiceCenterId);

            //entity.HasMany(e => e.SpreadsheetCollections)
            //    .WithOne(e => e.User)
            //    .HasForeignKey(k => k.UserId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //entity.HasOne(e => e.Vendor)
            //    .WithMany(e => e.ApplicationUsers)
            //    .HasForeignKey(k => k.VendorId);
        }
    }
}