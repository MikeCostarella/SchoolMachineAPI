using Microsoft.EntityFrameworkCore;

namespace SchoolMachine.DataAccess.Entities.Models.Security.Extensions
{
    public static class GroupRoleExtensions
    {
        /// <summary>
        /// Defines model relationships for the model builder of the db context
        /// Note: Currently not in use because we are using default EF model builder behavior instead
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void GroupRoleRelationships(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupRole>()
                .HasOne(groupRole => groupRole.Role)
                .WithMany(role => role.Teams)
                .HasForeignKey(groupRole => groupRole.RoleId)
                .HasConstraintName("foreignkey_grouprole_role");
            modelBuilder.Entity<GroupRole>()
                .HasOne(groupRole => groupRole.Group)
                .WithMany(group => group.Roles)
                .HasForeignKey(groupRole => groupRole.GroupId)
                .HasConstraintName("foreignkey_grouprole_group");
        }
    }
}
