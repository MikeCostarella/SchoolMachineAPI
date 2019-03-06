using Microsoft.EntityFrameworkCore;
using SchoolMachine.DataAccess.Entities.SchoolData.Models;

namespace SchoolMachine.DataAccess.Entities.Extensions
{
    public static class SchoolStudentExtensions
    {

        /// <summary>
        /// Defines model relationships for the model builder of the db context
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void DefineModelRelationships(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolStudent>()
                .HasOne(p => p.Student)
                .WithMany(b => b.SchoolStudents)
                .HasForeignKey(p => p.StudentId)
                .HasConstraintName("foreignkey_schoolstudent_student");
            modelBuilder.Entity<SchoolStudent>()
                .HasOne(p => p.School)
                .WithMany(b => b.Students)
                .HasForeignKey(p => p.SchoolId)
                .HasConstraintName("foreignkey_schoolstudent_school");
        }
    }
}
