using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using SchoolMachine.DataAccess.Entities.SeedData.Base;
using System;
using System.Collections.Generic;

namespace SchoolMachine.DataAccess.Entities.SeedData.Model.SchoolData
{
    public class StudentSeeder : DataSeederBase<Student>
    {
        protected override void Initialize()
        {
            base.Initialize();
            Objects = new List<Student>
            {
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/01/2005"), FirstName = "John", MiddleName = "Alfred", LastName = "Abott" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("11/10/2005"), FirstName = "Ann", MiddleName = "Grace", LastName = "Smith" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("09/01/2004"), FirstName = "Bill", MiddleName = "Anthony", LastName = "Kriter" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("01/01/2005"), FirstName = "Sara", MiddleName = "Lynn", LastName = "Carter" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/01/2006"), FirstName = "John", MiddleName = "Dudley", LastName = "Timkin" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("09/01/2008"), FirstName = "Abby", MiddleName = "Darla", LastName = "Smart" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/03/2008"), FirstName = "Ronald", MiddleName = "Burger", LastName = "McDonald" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("01/10/2009"), FirstName = "James", MiddleName = "Theodore", LastName = "Kirk" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/10/2006"), FirstName = "Donald", MiddleName = "John", LastName = "Trump" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/10/2006"), FirstName = "Barack", MiddleName = "Hussein", LastName = "Obama" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/10/2006"), FirstName = "William", MiddleName = "Jefferson", LastName = "Clinton" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/10/2006"), FirstName = "Riahna", MiddleName = "Darla", LastName = "Fabian" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/10/2006"), FirstName = "Janet", MiddleName = "Philomena", LastName = "Flores" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/10/2006"), FirstName = "Daffy", MiddleName = "Junior", LastName = "Duck" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/10/2006"), FirstName = "William", MiddleName = "Daryl", LastName = "Smart" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/10/2006"), FirstName = "Joe", MiddleName = "Bagga", LastName = "Donuts" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/10/2006"), FirstName = "Roger", MiddleName = "The", LastName = "Doger" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/10/2006"), FirstName = "Bernie", MiddleName = "QB", LastName = "Kosar" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/10/2006"), FirstName = "Rictor", MiddleName = "The", LastName = "Scale" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/10/2006"), FirstName = "Brian", MiddleName = "Donald", LastName = "Man" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/10/2006"), FirstName = "Wilomena", MiddleName = "Darla", LastName = "Rogers" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/10/2006"), FirstName = "Lovely", MiddleName = "Ionez", LastName = "Beefton" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/10/2006"), FirstName = "Jane", MiddleName = "Alla", LastName = "Doe" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/10/2006"), FirstName = "William", MiddleName = "Henry", LastName = "Harrison" },
                new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("02/10/2010"), FirstName = "Jared", MiddleName = "Henry", LastName = "Tullet" }
            };
        }
    }
}
