using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models.Security
{
    [Table("user_role", Schema = "security")]
    public class UserRole
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("role_id")]
        [Required(ErrorMessage = "Role Id is required")]
        public Guid RoleId { get; set; }
        [JsonIgnore]
        public Role Role { get; set; }

        [Column("user_id")]
        [Required(ErrorMessage = "User Id is required")]
        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
