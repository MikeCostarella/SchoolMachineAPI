using Microsoft.EntityFrameworkCore;

namespace SchoolMachine.DataAccess.Entities.Models.Security.Extensions
{
    public static class UserRoleExtension
    {
        /// <summary>
        /// Defines model relationships for the model builder of the db context
        /// Note: Currently not in use because we are using default EF model builder behavior instead
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void UserRoleRelationships(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasOne(userRole => userRole.User)
                .WithMany(user => user.Roles)
                .HasForeignKey(userRole => userRole.UserId)
                .HasConstraintName("foreignkey_userRole_user");
            modelBuilder.Entity<UserRole>()
                .HasOne(userRole => userRole.Role)
                .WithMany(role => role.Users)
                .HasForeignKey(userRole => userRole.RoleId)
                .HasConstraintName("foreignkey_userRole_role");
        }
    }
}
