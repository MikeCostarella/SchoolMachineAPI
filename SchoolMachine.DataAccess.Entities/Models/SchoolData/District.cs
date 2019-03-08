﻿using Newtonsoft.Json;
using SchoolMachine.DataAccess.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models.SchoolData
{
    [Table("district", Schema = "schooldata")]
    public class District : IEntity, INamedEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }

        [JsonIgnore]
        public List<DistrictSchool> Districts { get; set; }
    }
}
