using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models.Security
{
    [Table("team_role", Schema = "security")]
    public class TeamRole
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("date_created")]
        [Required(ErrorMessage = "Registration date is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Column("role_id")]
        [Required(ErrorMessage = "Role Id is required")]
        public Guid RoleId { get; set; }
        [JsonIgnore]
        public Role Role { get; set; }

        [Column("team_id")]
        [Required(ErrorMessage = "Team Id is required")]
        public Guid TeamId { get; set; }
        [JsonIgnore]
        public Team Team { get; set; }
    }
}
