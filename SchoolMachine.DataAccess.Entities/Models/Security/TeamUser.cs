using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models.Security
{
    [Table("TeamUsers", Schema = "Security")]
    public class TeamUser
    {
        [Key]
        [Column("TeamUserId")]
        public Guid Id { get; set; }

        [Column("DateCreated")]
        [Required(ErrorMessage = "Registration date is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Team Id is required")]
        public Guid TeamId { get; set; }

        [Required(ErrorMessage = "User Id is required")]
        public Guid UserId { get; set; }
    }
}
