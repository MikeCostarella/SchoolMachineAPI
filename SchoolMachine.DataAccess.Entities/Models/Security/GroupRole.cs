using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models.Security
{
    [Table("group_role", Schema = "security")]
    public class GroupRole
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("role_id")]
        [Required(ErrorMessage = "Role Id is required")]
        public Guid RoleId { get; set; }
        [JsonIgnore]
        public Role Role { get; set; }

        [Column("group_id")]
        [Required(ErrorMessage = "Group Id is required")]
        public Guid GroupId { get; set; }
        [JsonIgnore]
        public Group Group { get; set; }
    }
}
