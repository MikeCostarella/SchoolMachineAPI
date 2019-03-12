using SchoolMachine.DataAccess.Entities.Models.Geolocation;
using SchoolMachine.DataAccess.Entities.SeedData.Base;
using System;
using System.Collections.Generic;

namespace SchoolMachine.DataAccess.Entities.SeedData.Model.Geolocation
{
    public class StateSeeder : DataSeederBase<State>
    {
        protected override void Initialize()
        {
            base.Initialize();
            Objects = new List<State>
            {
                new State { Id = Guid.NewGuid(), Name = "Alabama", Abbreviation = "AL", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Alaska", Abbreviation = "AK", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Arizona", Abbreviation = "AZ", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Arkansas", Abbreviation = "AR", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "California", Abbreviation = "CA", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Colorado", Abbreviation = "CO", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Connecticut", Abbreviation = "CT", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Delaware", Abbreviation = "DE", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Florida", Abbreviation = "FL", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Georgia", Abbreviation = "GA", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Hawaii", Abbreviation = "HI", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Idaho", Abbreviation = "ID", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Illinois", Abbreviation = "IL", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Indiana", Abbreviation = "IN", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Iowa", Abbreviation = "IA", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Kansas", Abbreviation = "KS", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Kentucky", Abbreviation = "KY", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Louisiana", Abbreviation = "LA", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Maine", Abbreviation = "ME", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Maryland", Abbreviation = "MD", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Massachusetts", Abbreviation = "MA", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Michigan", Abbreviation = "MI", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Minnesota", Abbreviation = "MN", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Mississippi", Abbreviation = "MS", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Missouri", Abbreviation = "MO", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Montana", Abbreviation = "MT", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Nebraska", Abbreviation = "NE", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Nevada", Abbreviation = "NV", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "New Hampshire", Abbreviation = "NH", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "New Jersey", Abbreviation = "NJ", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "New Mexico", Abbreviation = "NM", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "New York", Abbreviation = "NY", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "North Carolina", Abbreviation = "NC", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "North Dakota", Abbreviation = "ND", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Ohio", Abbreviation = "OH", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Oklahoma", Abbreviation = "OK", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Oregon", Abbreviation = "OR", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Pennsylvania", Abbreviation = "PA", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Rhode Island", Abbreviation = "RI", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "South Carolina", Abbreviation = "SC", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "South Dakota", Abbreviation = "SD", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Tennessee", Abbreviation = "TN", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Texas", Abbreviation = "TX", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Utah", Abbreviation = "UT", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Vermont", Abbreviation = "VT", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Virginia", Abbreviation = "VA", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Washington", Abbreviation = "WA", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "West Virginia", Abbreviation = "WV", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Wisconsin", Abbreviation = "WI", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Wyoming", Abbreviation = "WY", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "American Samoa", Abbreviation = "AS", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "District of Columbia", Abbreviation = "DC", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Federated States of Micronesia", Abbreviation = "FM", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Guam", Abbreviation = "GU", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Marshall Islands", Abbreviation = "MH", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Northern Mariana Islands", Abbreviation = "MP", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Palau", Abbreviation = "PW", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Puerto Rico", Abbreviation = "PR", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Virgin Islands", Abbreviation = "VI", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Armed Forces Africa", Abbreviation = "AE", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Armed Forces Americas", Abbreviation = "AA", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Armed Forces Canada", Abbreviation = "AE", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Armed Forces Europe", Abbreviation = "AE", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Armed Forces Middle East", Abbreviation = "AE", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Armed Forces Pacific", Abbreviation = "AP", CountryId = DataSeeder.CountrySeeder.Dictionary["United States"].Id },
                new State { Id = Guid.NewGuid(), Name = "Alberta", Abbreviation = "AB", CountryId = DataSeeder.CountrySeeder.Dictionary["Canada"].Id },
                new State { Id = Guid.NewGuid(), Name = "British Columbia", Abbreviation = "BC", CountryId = DataSeeder.CountrySeeder.Dictionary["Canada"].Id },
                new State { Id = Guid.NewGuid(), Name = "Manitoba", Abbreviation = "MB", CountryId = DataSeeder.CountrySeeder.Dictionary["Canada"].Id },
                new State { Id = Guid.NewGuid(), Name = "New Brunswick", Abbreviation = "NB", CountryId = DataSeeder.CountrySeeder.Dictionary["Canada"].Id },
                new State { Id = Guid.NewGuid(), Name = "Newfoundland and Labrador", Abbreviation = "NL", CountryId = DataSeeder.CountrySeeder.Dictionary["Canada"].Id },
                new State { Id = Guid.NewGuid(), Name = "Nova Scotia", Abbreviation = "NS", CountryId = DataSeeder.CountrySeeder.Dictionary["Canada"].Id },
                new State { Id = Guid.NewGuid(), Name = "Northwest Territories", Abbreviation = "NT", CountryId = DataSeeder.CountrySeeder.Dictionary["Canada"].Id },
                new State { Id = Guid.NewGuid(), Name = "Nunavut", Abbreviation = "NU", CountryId = DataSeeder.CountrySeeder.Dictionary["Canada"].Id },
                new State { Id = Guid.NewGuid(), Name = "Ontario", Abbreviation = "ON", CountryId = DataSeeder.CountrySeeder.Dictionary["Canada"].Id },
                new State { Id = Guid.NewGuid(), Name = "Prince Edward Island", Abbreviation = "PE", CountryId = DataSeeder.CountrySeeder.Dictionary["Canada"].Id },
                new State { Id = Guid.NewGuid(), Name = "Quebec", Abbreviation = "QC", CountryId = DataSeeder.CountrySeeder.Dictionary["Canada"].Id },
                new State { Id = Guid.NewGuid(), Name = "Saskatchewan", Abbreviation = "SK", CountryId = DataSeeder.CountrySeeder.Dictionary["Canada"].Id },
                new State { Id = Guid.NewGuid(), Name = "Yukon", Abbreviation = "YT", CountryId = DataSeeder.CountrySeeder.Dictionary["Canada"].Id }
            };
        }
    }
}
