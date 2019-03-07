using Microsoft.EntityFrameworkCore;

namespace SchoolMachine.DataAccess.Entities.Models.Security.Extensions
{
    public static class TeamUserExtensions
    {
        /// <summary>
        /// Defines model relationships for the model builder of the db context
        /// Note: Currently not in use because we are using default EF model builder behavior instead
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void TeamUserRelationships(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamUser>()
                .HasOne(teamUser => teamUser.User)
                .WithMany(user => user.Teams)
                .HasForeignKey(teamRole => teamRole.UserId)
                .HasConstraintName("foreignkey_teamuser_user");
            modelBuilder.Entity<TeamUser>()
                .HasOne(teamUser => teamUser.Team)
                .WithMany(team => team.Users)
                .HasForeignKey(teamUser => teamUser.TeamId)
                .HasConstraintName("foreignkey_teamuser_team");
        }
    }
}
