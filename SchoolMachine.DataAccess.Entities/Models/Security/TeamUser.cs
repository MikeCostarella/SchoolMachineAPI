using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models.Security
{
    [Table("team_users", Schema = "security")]
    public class TeamUser
    {
        [Key]
        [Column("team_user_id")]
        public Guid Id { get; set; }

        [Column("date_created")]
        [Required(ErrorMessage = "Registration date is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Column("team_id")]
        [Required(ErrorMessage = "Team Id is required")]
        public Guid TeamId { get; set; }

        [Column("user_id")]
        [Required(ErrorMessage = "User Id is required")]
        public Guid UserId { get; set; }
    }
}
