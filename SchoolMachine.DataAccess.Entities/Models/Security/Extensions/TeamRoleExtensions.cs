using Microsoft.EntityFrameworkCore;

namespace SchoolMachine.DataAccess.Entities.Models.Security.Extensions
{
    public static class TeamRoleExtensions
    {
        /// <summary>
        /// Defines model relationships for the model builder of the db context
        /// Note: Currently not in use because we are using default EF model builder behavior instead
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void TeamRoleRelationships(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamRole>()
                .HasOne(teamRole => teamRole.Role)
                .WithMany(role => role.Teams)
                .HasForeignKey(teamRole => teamRole.RoleId)
                .HasConstraintName("foreignkey_teamrole_role");
            modelBuilder.Entity<TeamRole>()
                .HasOne(teamRole => teamRole.Team)
                .WithMany(team => team.Roles)
                .HasForeignKey(teamRole => teamRole.TeamId)
                .HasConstraintName("foreignkey_teamrole_team");
        }
    }
}
