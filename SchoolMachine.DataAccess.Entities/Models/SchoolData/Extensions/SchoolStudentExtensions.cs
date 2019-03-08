using Microsoft.EntityFrameworkCore;

namespace SchoolMachine.DataAccess.Entities.Models.SchoolData.Extensions
{
    public static class SchoolStudentExtensions
    {
        /// <summary>
        /// Defines model relationships for the model builder of the db context
        /// Note: Currently not in use because we are using default EF model builder behavior instead
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void SchoolStudentRelationships(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolStudent>()
                .HasOne(schoolStudent => schoolStudent.Student)
                .WithMany(student => student.Schools)
                .HasForeignKey(schoolStudent => schoolStudent.StudentId)
                .HasConstraintName("foreignkey_schoolstudent_student");
            modelBuilder.Entity<SchoolStudent>()
                .HasOne(schoolStudent => schoolStudent.School)
                .WithMany(school => school.Students)
                .HasForeignKey(schoolStudent => schoolStudent.SchoolId)
                .HasConstraintName("foreignkey_schoolstudent_school");
        }
    }
}
