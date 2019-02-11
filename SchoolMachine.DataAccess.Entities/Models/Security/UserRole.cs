using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models.Security
{
    [Table("UserRoles", Schema = "Security")]
    public class UserRole
    {
        [Key]
        [Column("UserRoleId")]
        public Guid Id { get; set; }

        [Column("DateCreated")]
        [Required(ErrorMessage = "DateCreated is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Role Id is required")]
        public Guid RoleId { get; set; }

        [Required(ErrorMessage = "User Id is required")]
        public Guid UserId { get; set; }
    }
}
