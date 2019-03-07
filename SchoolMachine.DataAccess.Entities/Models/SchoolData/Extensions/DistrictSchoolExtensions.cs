using Microsoft.EntityFrameworkCore;

namespace SchoolMachine.DataAccess.Entities.Models.SchoolData.Extensions
{
    public static class DistrictSchoolExtensions
    {
        /// <summary>
        /// Defines model relationships for the model builder of the db context
        /// Note: Currently not in use because we are using default EF model builder behavior instead
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void DistrictSchoolRelationships(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DistrictSchool>()
                .HasOne(districtSchool => districtSchool.District)
                .WithMany(district => district.Districts)
                .HasForeignKey(districtSchool => districtSchool.DistrictId)
                .HasConstraintName("foreignkey_districtschool_district");
            modelBuilder.Entity<DistrictSchool>()
                .HasOne(districtSchool => districtSchool.School)
                .WithMany(district => district.Districts)
                .HasForeignKey(districtSchool => districtSchool.SchoolId)
                .HasConstraintName("foreignkey_districtschool_school");
        }
    }
}
