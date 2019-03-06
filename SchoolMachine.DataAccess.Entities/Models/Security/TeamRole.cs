using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models.Security
{
    [Table("team_roles", Schema = "security")]
    public class TeamRole
    {
        [Key]
        [Column("team_role_id")]
        public Guid Id { get; set; }

        [Column("date_created")]
        [Required(ErrorMessage = "Registration date is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Column("role_id")]
        [Required(ErrorMessage = "Role Id is required")]
        public Guid RoleId { get; set; }

        [Column("team_id")]
        [Required(ErrorMessage = "Team Id is required")]
        public Guid TeamId { get; set; }
    }
}
