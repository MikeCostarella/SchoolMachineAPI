using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models.Security
{
    [Table("Roles", Schema = "Security")]
    public class Role
    {
        [Key]
        [Column("RoleId")]
        public Guid Id { get; set; }

        [Column("DateCreated")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Column("Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }

        [Column("Description")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000, ErrorMessage = "Description can't be longer than 1000 characters")]
        public string Description { get; set; }

        [Column("IsActive")]
        public bool IsActive { get; set; } = true;
    }
}
