using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models.Security
{
    [Table("TeamRoles", Schema = "Security")]
    public class TeamRole
    {
        [Key]
        [Column("TeamRoleId")]
        public Guid Id { get; set; }

        [Column("DateCreated")]
        [Required(ErrorMessage = "Registration date is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Role Id is required")]
        public Guid RoleId { get; set; }

        [Required(ErrorMessage = "Team Id is required")]
        public Guid TeamId { get; set; }
    }
}
