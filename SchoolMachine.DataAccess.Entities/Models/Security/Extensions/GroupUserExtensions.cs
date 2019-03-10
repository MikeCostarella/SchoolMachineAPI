using Microsoft.EntityFrameworkCore;

namespace SchoolMachine.DataAccess.Entities.Models.Security.Extensions
{
    public static class GroupUserExtensions
    {
        /// <summary>
        /// Defines model relationships for the model builder of the db context
        /// Note: Currently not in use because we are using default EF model builder behavior instead
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void GroupUserRelationships(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupUser>()
                .HasOne(groupUser => groupUser.User)
                .WithMany(user => user.Teams)
                .HasForeignKey(groupRole => groupRole.UserId)
                .HasConstraintName("foreignkey_groupuser_user");
            modelBuilder.Entity<GroupUser>()
                .HasOne(groupUser => groupUser.Group)
                .WithMany(group => group.Users)
                .HasForeignKey(groupUser => groupUser.GroupId)
                .HasConstraintName("foreignkey_groupuser_group");
        }
    }
}
