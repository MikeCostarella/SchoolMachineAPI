using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models.Security
{
    [Table("user", Schema = "security")]
    public class User
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("date_created")]
        [Required(ErrorMessage = "DateCreated is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Column("first_name")]
        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(50, ErrorMessage = "FirstName can't be longer than 50 characters")]
        public string FirstName { get; set; }

        [Column("middle_name")]
        [Required(ErrorMessage = "MiddleName is required")]
        [StringLength(50, ErrorMessage = "MiddleName can't be longer than 50 characters")]
        public string MiddleName { get; set; }

        [Column("last_name")]
        [Required(ErrorMessage = "LastName is required")]
        [StringLength(50, ErrorMessage = "LastName can't be longer than 50 characters")]
        public string LastName { get; set; }

        [Column("user_name")]
        [Required(ErrorMessage = "UserName is required")]
        [StringLength(50, ErrorMessage = "UserName can't be longer than 50 characters")]
        public string UserName { get; set; }

        [Column("email_address")]
        [Required(ErrorMessage = "EmailAddress is required")]
        [StringLength(150, ErrorMessage = "EmailAddress can't be longer than 150 characters")]
        public string EmailAddress { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        [Column("password_hash")]
        public byte[] PasswordHash { get; set; }

        [Column("password_salt")]
        public byte[] PasswordSalt { get; set; }

        [JsonIgnore]
        public List<UserRole> Roles { get; set; }

        [JsonIgnore]
        public List<GroupUser> Teams { get; set; }

    }
}
