using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models.Security
{
    [Table("Users", Schema = "Security")]
    public class User
    {
        [Key]
        [Column("UserId")]
        public Guid Id { get; set; }

        [Column("DateCreated")]
        [Required(ErrorMessage = "DateCreated is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Column("FirstName")]
        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(50, ErrorMessage = "FirstName can't be longer than 50 characters")]
        public string FirstName { get; set; }

        [Column("MiddleName")]
        [Required(ErrorMessage = "MiddleName is required")]
        [StringLength(50, ErrorMessage = "MiddleName can't be longer than 50 characters")]
        public string MiddleName { get; set; }

        [Column("LastName")]
        [Required(ErrorMessage = "LastName is required")]
        [StringLength(50, ErrorMessage = "LastName can't be longer than 50 characters")]
        public string LastName { get; set; }

        [Column("UserName")]
        [Required(ErrorMessage = "UserName is required")]
        [StringLength(50, ErrorMessage = "UserName can't be longer than 50 characters")]
        public string UserName { get; set; }

        [Column("EmailAddress")]
        [Required(ErrorMessage = "EmailAddress is required")]
        [StringLength(150, ErrorMessage = "EmailAddress can't be longer than 150 characters")]
        public string EmailAddress { get; set; }

        [Column("IsActive")]
        public bool IsActive { get; set; } = true;

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

    }
}
