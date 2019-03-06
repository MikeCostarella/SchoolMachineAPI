using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models.Security
{
    [Table("user_roles", Schema = "security")]
    public class UserRole
    {
        [Key]
        [Column("user_role_id")]
        public Guid Id { get; set; }

        [Column("date_created")]
        [Required(ErrorMessage = "DateCreated is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Column("role_id")]
        [Required(ErrorMessage = "Role Id is required")]
        public Guid RoleId { get; set; }

        [Column("user_id")]
        [Required(ErrorMessage = "User Id is required")]
        public Guid UserId { get; set; }
    }
}
