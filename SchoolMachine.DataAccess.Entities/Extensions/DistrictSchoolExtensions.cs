using Microsoft.EntityFrameworkCore;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;

namespace SchoolMachine.DataAccess.Entities.Extensions
{
    public static class DistrictSchoolExtensions
    {

        /// <summary>
        /// Defines model relationships for the model builder of the db context
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void DefineModelRelationships(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DistrictSchool>()
                .HasOne(p => p.District)
                .WithMany(b => b.Districts)
                .HasForeignKey(p => p.DistrictId)
                .HasConstraintName("foreignkey_districtschool_district");
            modelBuilder.Entity<DistrictSchool>()
                .HasOne(p => p.School)
                .WithMany(b => b.Districts)
                .HasForeignKey(p => p.SchoolId)
                .HasConstraintName("foreignkey_districtschool_school");
        }
    }
}
