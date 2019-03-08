using Newtonsoft.Json;
using SchoolMachine.DataAccess.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolMachine.DataAccess.Entities.SchoolData.Models
{
    [Table("student", Schema = "schooldata")]
    public class Student : IEntity, INamedEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("first_name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(60, ErrorMessage = "First Name can't be longer than 60 characters")]
        public string FirstName { get; set; }

        [Column("last_name")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(60, ErrorMessage = "Last Name can't be longer than 60 characters")]
        public string LastName { get; set; }

        [Column("middle_name")]
        [Required(ErrorMessage = "Middle Name is required")]
        [StringLength(60, ErrorMessage = "Middle Name can't be longer than 60 characters")]
        public string MiddleName { get; set; }

        [Column("birth_date")]
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime BirthDate { get; set; }

        [NotMapped]
        [JsonIgnore]
        public string Name
        {
            get
            {
                var sb = new StringBuilder();
                sb
                    .Append(FirstName.Trim())
                    .Append(FirstName.Trim().Length > 0 ? " " : string.Empty)
                    .Append(MiddleName.Trim())
                    .Append(MiddleName.Trim().Length > 0 ? " " : string.Empty)
                    .Append(LastName.Trim());
                var name = sb.ToString();
                if (!string.IsNullOrEmpty(name)) sb.Append(" ");
                sb.Append(BirthDate.ToString());
                return sb.ToString();
            }
        }

        [JsonIgnore]
        public List<SchoolStudent> Schools { get; set; }
    }
}
