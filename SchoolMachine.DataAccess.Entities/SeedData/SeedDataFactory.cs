using SchoolMachine.DataAccess.Entities.Models;
using System;
using System.Collections.Generic;

namespace SchoolMachine.DataAccess.Entities.SeedData
{
    public static class SeedDataFactory
    {
        public static List<School> Schools = new List<School>
        {
            new School { Id = Guid.NewGuid(), Name = "Girard High School" },
            new School { Id = Guid.NewGuid(), Name = "Liberty High School" }
        };

        public static List<Student> Students = new List<Student>
        {
            new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/01/2005"), FirstName = "John", MiddleName = "Alfred", LastName = "Abott" },
            new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("11/10/2005"), FirstName = "Ann", MiddleName = "Grace", LastName = "Smith" },
            new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("09/01/2004"), FirstName = "Bill", MiddleName = "Anthony", LastName = "Kriter" },
            new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("01/01/2005"), FirstName = "Sara", MiddleName = "Lynn", LastName = "Carter" },
            new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/01/2006"), FirstName = "John", MiddleName = "Dudley", LastName = "Timkin" }
        };

    }
}
