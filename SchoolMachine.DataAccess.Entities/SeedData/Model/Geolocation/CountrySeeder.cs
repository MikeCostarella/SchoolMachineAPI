using SchoolMachine.DataAccess.Entities.Models.Geolocation;
using SchoolMachine.DataAccess.Entities.SeedData.Base;
using System;
using System.Collections.Generic;

namespace SchoolMachine.DataAccess.Entities.SeedData.Model.Geolocation
{
    public class CountrySeeder : DataSeederBase<Country>
    {
        protected override void Initialize()
        {
            base.Initialize();
            Objects = new List<Country>
            {
                new Country { Id = Guid.NewGuid(), Abbreviation = "AC", Name = "Ascension Island" },
                new Country { Id = Guid.NewGuid(), Abbreviation = "AF", Name = "Afghanistan" },
                new Country { Id = Guid.NewGuid(), Abbreviation = "AX", Name = "Aland" },
                new Country { Id = Guid.NewGuid(), Abbreviation = "AL", Name = "Albania" },
                new Country { Id = Guid.NewGuid(), Abbreviation = "DZ", Name = "Algeria" },
                new Country { Id = Guid.NewGuid(), Abbreviation = "AD", Name = "Andorra" },
                new Country { Id = Guid.NewGuid(), Abbreviation = "AI", Name = "Anguilla" },
                new Country { Id = Guid.NewGuid(), Abbreviation = "AQ", Name = "Antartica" },
                new Country { Id = Guid.NewGuid(), Abbreviation = "AG", Name = "Antigua and Barbuda" },
                new Country { Id = Guid.NewGuid(), Abbreviation = "AT", Name = "Austria" },
                new Country { Id = Guid.NewGuid(), Abbreviation = "AU", Name = "Australia" },
                new Country { Id = Guid.NewGuid(), Abbreviation = "CA", Name = "Canada" },
                new Country { Id = Guid.NewGuid(), Abbreviation = "US", Name = "United States" }
            };
        }
    }
}
