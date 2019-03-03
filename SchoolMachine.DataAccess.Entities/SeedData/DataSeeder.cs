﻿using SchoolMachine.DataAccess.Entities.Models.Security;
using SchoolMachine.DataAccess.Entities.SchoolData.Models;
using System;
using System.Collections.Generic;

namespace SchoolMachine.DataAccess.Entities.SeedData
{
    public static class DataSeeder
    {
        public static List<Role> Roles = new List<Role>
        {
            new Role { Id = Guid.NewGuid(), Description = "Total access to all other roles", Name = "System Administrator" }
        };

        public static List<School> Schools = new List<School>
        {
            new School { Id = Guid.NewGuid(), Name = "Austintown Fitch High School" },
            new School { Id = Guid.NewGuid(), Name = "Canfield High School" },
            new School { Id = Guid.NewGuid(), Name = "Girard High School" },
            new School { Id = Guid.NewGuid(), Name = "Liberty High School" }
        };

        public static List<Student> Students = new List<Student>
        {
            new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/01/2005"), FirstName = "John", MiddleName = "Alfred", LastName = "Abott" },
            new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("11/10/2005"), FirstName = "Ann", MiddleName = "Grace", LastName = "Smith" },
            new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("09/01/2004"), FirstName = "Bill", MiddleName = "Anthony", LastName = "Kriter" },
            new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("01/01/2005"), FirstName = "Sara", MiddleName = "Lynn", LastName = "Carter" },
            new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/01/2006"), FirstName = "John", MiddleName = "Dudley", LastName = "Timkin" },
            new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/10/2006"), FirstName = "Abby", MiddleName = "Darla", LastName = "Smart" }
        };

        public static List<SchoolStudent> SchoolStudents = new List<SchoolStudent>
        {
            new SchoolStudent
            {
                DateCreated = DateTime.UtcNow,
                GradeLevel = "9",
                Id = Guid.NewGuid(),
                RegistrationDate = DateTime.UtcNow,
                SchoolId = Schools[0].Id,
                StudentId = Students[0].Id
            },
            new SchoolStudent
            {
                DateCreated = DateTime.UtcNow,
                GradeLevel = "9",
                Id = Guid.NewGuid(),
                RegistrationDate = DateTime.UtcNow,
                SchoolId = Schools[1].Id,
                StudentId = Students[1].Id
            },
            new SchoolStudent
            {
                DateCreated = DateTime.UtcNow,
                GradeLevel = "9",
                Id = Guid.NewGuid(),
                RegistrationDate = DateTime.UtcNow,
                SchoolId = Schools[1].Id,
                StudentId = Students[2].Id
            }
        };

        public static List<User> Users = new List<User>
        {
            new User
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.UtcNow,
                EmailAddress = "auser1@email.com",
                FirstName = "A",
                IsActive = true,
                LastName = "User1",
                MiddleName = "A",
                UserName = "auser1"
            }
        };
    }
}
