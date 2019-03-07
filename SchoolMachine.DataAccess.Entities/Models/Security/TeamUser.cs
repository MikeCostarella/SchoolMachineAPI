using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models.Security
{
    [Table("team_user", Schema = "security")]
    public class TeamUser
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("date_created")]
        [Required(ErrorMessage = "Registration date is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Column("team_id")]
        [Required(ErrorMessage = "Team Id is required")]
        public Guid TeamId { get; set; }
        [JsonIgnore]
        public Team Team { get; set; }

        [Column("user_id")]
        [Required(ErrorMessage = "User Id is required")]
        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
