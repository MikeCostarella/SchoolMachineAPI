﻿using Newtonsoft.Json;
using SchoolMachine.DataAccess.Entities.Interfaces;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMachine.DataAccess.Entities.Models.SchoolData
{
    [Table("school", Schema = "schooldata")]
    public class School : IEntity, INamedEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }

        [JsonIgnore]
        [Column("location_id")]
        public Guid LocationId { get; set; }

        [JsonIgnore]
        public List<SchoolStudent> Students { get; set; }

        [JsonIgnore]
        public List<DistrictSchool> Districts { get; set; }
    }
}