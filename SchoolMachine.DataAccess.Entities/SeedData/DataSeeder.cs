using SchoolMachine.DataAccess.Entities.Models.GeoLocation;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using SchoolMachine.DataAccess.Entities.Models.Security;
using System;
using System.Collections.Generic;

namespace SchoolMachine.DataAccess.Entities.SeedData
{
    public static class DataSeeder
    {
        #region Countries
        
        private static Dictionary<string, Country> _countryDictionary;
        public static Dictionary<string, Country> CountryDictionary
        {
            get
            {
                if (_countryDictionary == null)
                {
                    _countryDictionary = new Dictionary<string, Country>();
                    foreach (var obj in Countries)
                    {
                        _countryDictionary[obj.Abbreviation] = obj;
                    }
                }
                return _countryDictionary;
            }
            set { _countryDictionary = value; }
        }
        public static List<Country> Countries = new List<Country>
        {
            new Country { Id = Guid.NewGuid(), Abbreviation = "AC", Name = "Ascension Island" },
            new Country { Id = Guid.NewGuid(), Abbreviation = "AF", Name = "Afghanistan" },
            new Country { Id = Guid.NewGuid(), Abbreviation = "AX", Name = "Aland" },
            new Country { Id = Guid.NewGuid(), Abbreviation = "AL", Name = "Albania" },
            new Country { Id = Guid.NewGuid(), Abbreviation = "DZ", Name = "Algeria" },
            new Country { Id = Guid.NewGuid(), Abbreviation = "AD", Name = "Andorra" },
            new Country { Id = Guid.NewGuid(), Abbreviation = "AI", Name = "Anguilla" },
            new Country { Id = Guid.NewGuid(), Abbreviation = "AT", Name = "Austria" },
            new Country { Id = Guid.NewGuid(), Abbreviation = "AU", Name = "Australia" },
            new Country { Id = Guid.NewGuid(), Abbreviation = "CA", Name = "Canada" },
            new Country { Id = Guid.NewGuid(), Abbreviation = "US", Name = "United States" }
        };

        #endregion Countries

        #region States

        private static Dictionary<string, State> _stateDictionary;
        public static Dictionary<string, State> StateDictionary
        {
            get
            {
                if (_stateDictionary == null)
                {
                    _stateDictionary = new Dictionary<string, State>();
                    foreach (var obj in States)
                    {
                        _stateDictionary[obj.Name] = obj;
                    }
                }
                return _stateDictionary;
            }
            set { _stateDictionary = value; }
        }
        public static List<State> States = new List<State>
        {
            new State { Id = Guid.NewGuid(), Name = "Alabama", Abbreviation = "AL", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Alaska", Abbreviation = "AK", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Arizona", Abbreviation = "AZ", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Arkansas", Abbreviation = "AR", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "California", Abbreviation = "CA", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Colorado", Abbreviation = "CO", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Connecticut", Abbreviation = "CT", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Delaware", Abbreviation = "DE", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Florida", Abbreviation = "FL", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Georgia", Abbreviation = "GA", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Hawaii", Abbreviation = "HI", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Idaho", Abbreviation = "ID", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Illinois", Abbreviation = "IL", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Indiana", Abbreviation = "IN", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Iowa", Abbreviation = "IA", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Kansas", Abbreviation = "KS", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Kentucky", Abbreviation = "KY", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Louisiana", Abbreviation = "LA", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Maine", Abbreviation = "ME", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Maryland", Abbreviation = "MD", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Massachusetts", Abbreviation = "MA", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Michigan", Abbreviation = "MI", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Minnesota", Abbreviation = "MN", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Mississippi", Abbreviation = "MS", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Missouri", Abbreviation = "MO", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Montana", Abbreviation = "MT", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Nebraska", Abbreviation = "NE", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Nevada", Abbreviation = "NV", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "New Hampshire", Abbreviation = "NH", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "New Jersey", Abbreviation = "NJ", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "New Mexico", Abbreviation = "NM", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "New York", Abbreviation = "NY", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "North Carolina", Abbreviation = "NC", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "North Dakota", Abbreviation = "ND", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Ohio", Abbreviation = "OH", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Oklahoma", Abbreviation = "OK", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Oregon", Abbreviation = "OR", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Pennsylvania", Abbreviation = "PA", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Rhode Island", Abbreviation = "RI", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "South Carolina", Abbreviation = "SC", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "South Dakota", Abbreviation = "SD", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Tennessee", Abbreviation = "TN", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Texas", Abbreviation = "TX", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Utah", Abbreviation = "UT", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Vermont", Abbreviation = "VT", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Virginia", Abbreviation = "VA", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Washington", Abbreviation = "WA", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "West Virginia", Abbreviation = "WV", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Wisconsin", Abbreviation = "WI", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Wyoming", Abbreviation = "WY", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "American Samoa", Abbreviation = "AS", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "District of Columbia", Abbreviation = "DC", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Federated States of Micronesia", Abbreviation = "FM", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Guam", Abbreviation = "GU", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Marshall Islands", Abbreviation = "MH", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Northern Mariana Islands", Abbreviation = "MP", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Palau", Abbreviation = "PW", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Puerto Rico", Abbreviation = "PR", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Virgin Islands", Abbreviation = "VI", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Armed Forces Africa", Abbreviation = "AE", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Armed Forces Americas", Abbreviation = "AA", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Armed Forces Canada", Abbreviation = "AE", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Armed Forces Europe", Abbreviation = "AE", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Armed Forces Middle East", Abbreviation = "AE", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Armed Forces Pacific", Abbreviation = "AP", CountryId = CountryDictionary["US"].Id },
            new State { Id = Guid.NewGuid(), Name = "Alberta", Abbreviation = "AB", CountryId = CountryDictionary["CA"].Id },
            new State { Id = Guid.NewGuid(), Name = "British Columbia", Abbreviation = "BC", CountryId = CountryDictionary["CA"].Id },
            new State { Id = Guid.NewGuid(), Name = "Manitoba", Abbreviation = "MB", CountryId = CountryDictionary["CA"].Id },
            new State { Id = Guid.NewGuid(), Name = "New Brunswick", Abbreviation = "NB", CountryId = CountryDictionary["CA"].Id },
            new State { Id = Guid.NewGuid(), Name = "Newfoundland and Labrador", Abbreviation = "NL", CountryId = CountryDictionary["CA"].Id },
            new State { Id = Guid.NewGuid(), Name = "Nova Scotia", Abbreviation = "NS", CountryId = CountryDictionary["CA"].Id },
            new State { Id = Guid.NewGuid(), Name = "Northwest Territories", Abbreviation = "NT", CountryId = CountryDictionary["CA"].Id },
            new State { Id = Guid.NewGuid(), Name = "Nunavut", Abbreviation = "NU", CountryId = CountryDictionary["CA"].Id },
            new State { Id = Guid.NewGuid(), Name = "Ontario", Abbreviation = "ON", CountryId = CountryDictionary["CA"].Id },
            new State { Id = Guid.NewGuid(), Name = "Prince Edward Island", Abbreviation = "PE", CountryId = CountryDictionary["CA"].Id },
            new State { Id = Guid.NewGuid(), Name = "Quebec", Abbreviation = "QC", CountryId = CountryDictionary["CA"].Id },
            new State { Id = Guid.NewGuid(), Name = "Saskatchewan", Abbreviation = "SK", CountryId = CountryDictionary["CA"].Id },
            new State { Id = Guid.NewGuid(), Name = "Yukon", Abbreviation = "YT", CountryId = CountryDictionary["CA"].Id },
        };

        #endregion States

        #region Districts

        private static Dictionary<string, District> _districtDictionary;
        public static Dictionary<string, District> DistrictDictionary
        {
            get
            {
                if (_districtDictionary == null)
                {
                    _districtDictionary = new Dictionary<string, District>();
                    foreach (var obj in Districts)
                    {
                        _districtDictionary[obj.Name] = obj;
                    }
                }
                return _districtDictionary;
            }
            set { _districtDictionary = value; }
        }
        public static List<District> Districts = new List<District>
        {
            new District { Id = Guid.NewGuid(), Name = "Austintown Local School District" },
            new District { Id = Guid.NewGuid(), Name = "Bloomfield-Mespo Local School District" },
            new District { Id = Guid.NewGuid(), Name = "Boardman Local School District" },
            new District { Id = Guid.NewGuid(), Name = "Bristol Local School District" },
            new District { Id = Guid.NewGuid(), Name = "Brookfield Local School District" },
            new District { Id = Guid.NewGuid(), Name = "Canfield Local School District" },
            new District { Id = Guid.NewGuid(), Name = "Champion Local School District" },
            new District { Id = Guid.NewGuid(), Name = "Girard City School District" },
            new District { Id = Guid.NewGuid(), Name = "Howland Local School District" },
            new District { Id = Guid.NewGuid(), Name = "Hubbard Exempted Village School District" },
            new District { Id = Guid.NewGuid(), Name = "Howland Local School District" },
            new District { Id = Guid.NewGuid(), Name = "Hubbard Exempted Village School District" },
            new District { Id = Guid.NewGuid(), Name = "Jackson-Milton Local School District" },
            new District { Id = Guid.NewGuid(), Name = "Joseph Badger Local School District" },
            new District { Id = Guid.NewGuid(), Name = "LaBrae Local School District" },
            new District { Id = Guid.NewGuid(), Name = "Lakeview Local School District" },
            new District { Id = Guid.NewGuid(), Name = "Liberty Local School District" },
            new District { Id = Guid.NewGuid(), Name = "Lordstown Local School District" },
            new District { Id = Guid.NewGuid(), Name = "Lowellville Local School District" },
            new District { Id = Guid.NewGuid(), Name = "Maplewood Local School District" },
            new District { Id = Guid.NewGuid(), Name = "Mathews Local School District" },
            new District { Id = Guid.NewGuid(), Name = "McDonald Local School District" },
            new District { Id = Guid.NewGuid(), Name = "Newton Falls Exempted Village School District" },
            new District { Id = Guid.NewGuid(), Name = "Niles City School District" },
            new District { Id = Guid.NewGuid(), Name = "Sebring Local School District" },
            new District { Id = Guid.NewGuid(), Name = "Southington Local School District" },
            new District { Id = Guid.NewGuid(), Name = "South Range Local School District" },
            new District { Id = Guid.NewGuid(), Name = "Springfield Local School District" },
            new District { Id = Guid.NewGuid(), Name = "Struthers City School District" },
            new District { Id = Guid.NewGuid(), Name = "Trumbull Career & Technical Center" },
            new District { Id = Guid.NewGuid(), Name = "Trumbull County Educational Service Center" },
            new District { Id = Guid.NewGuid(), Name = "Warren City School District" },
            new District { Id = Guid.NewGuid(), Name = "Weathersfield Local School District" },
            new District { Id = Guid.NewGuid(), Name = "West Branch Local School District" },
            new District { Id = Guid.NewGuid(), Name = "Western Reserve Local School District" },
            new District { Id = Guid.NewGuid(), Name = "Youngstown City School District" }
        };

        #endregion Districts

        #region Locations

        public static List<Location> Locations = new List<Location>
        {
            new Location { Id = Guid.NewGuid(), Description = "GHS Main Entrance", Street1 = "1244", Street2 = "Shannon Rd.", City = "Girard", State = "OH", PostalCode = "44420", Country = "USA", Latitude = 41.171231, Longitude = -80.691469 }
        };

        #endregion Locations

        #region Schools

        private static Dictionary<string, School> _schoolDictionary;
        public static Dictionary<string, School> SchoolDictionary
        {
            get
            {
                if (_schoolDictionary == null)
                {
                    _schoolDictionary = new Dictionary<string, School>();
                    foreach (var obj in Schools)
                    {
                        _schoolDictionary[obj.Name] = obj;
                    }
                }
                return _schoolDictionary;
            }
            set { _schoolDictionary = value; }
        }
        public static List<School> Schools = new List<School>
        {
            new School { Id = Guid.NewGuid(), Name = "Austintown Fitch High School" },
            new School { Id = Guid.NewGuid(), Name = "Badger Elementary School" },
            new School { Id = Guid.NewGuid(), Name = "Badger Middle School" },
            new School { Id = Guid.NewGuid(), Name = "Badger High School" },
            new School { Id = Guid.NewGuid(), Name = "Bloomfield Middle/High School" },
            new School { Id = Guid.NewGuid(), Name = "Bristol Elementary" },
            new School { Id = Guid.NewGuid(), Name = "Bristol Middle & High School" },
            new School { Id = Guid.NewGuid(), Name = "Brookfield Elementary School" },
            new School { Id = Guid.NewGuid(), Name = "Brookfield Middle School" },
            new School { Id = Guid.NewGuid(), Name = "Brookfield High School" },
            new School { Id = Guid.NewGuid(), Name = "Canfield High School" },
            new School { Id = Guid.NewGuid(), Name = "Central Elementary" }, // Champion Local School District
            new School { Id = Guid.NewGuid(), Name = "Champion High School" },
            new School { Id = Guid.NewGuid(), Name = "Champion Middle School" },
            new School { Id = Guid.NewGuid(), Name = "Girard High School", LocationId = Locations[0].Id },
            new School { Id = Guid.NewGuid(), Name = "Girard Intermediate" },
            new School { Id = Guid.NewGuid(), Name = "Girard Junior High School" },
            new School { Id = Guid.NewGuid(), Name = "Glen Primary School" }, // Howland Local School District
            new School { Id = Guid.NewGuid(), Name = "H.C. Mines Elementary" }, // Howland Local School District
            new School { Id = Guid.NewGuid(), Name = "Hubbard Elementary School" },
            new School { Id = Guid.NewGuid(), Name = "Hubbard High School" },
            new School { Id = Guid.NewGuid(), Name = "Hubbard Middle School" },
            new School { Id = Guid.NewGuid(), Name = "Howland High School" },
            new School { Id = Guid.NewGuid(), Name = "Howland Middle School" },
            new School { Id = Guid.NewGuid(), Name = "Liberty High School" },
            new School { Id = Guid.NewGuid(), Name = "Mesopatamia Elementary" }, // Bloomfield-Mespo Local School District
            new School { Id = Guid.NewGuid(), Name = "North Road Intermediate" }, // Howland Local School District
            new School { Id = Guid.NewGuid(), Name = "Prospect Elementary" }, // Girard City School District
            new School { Id = Guid.NewGuid(), Name = "Springs Primary School" }, // Howland Local School District
            new School { Id = Guid.NewGuid(), Name = "Trumbull Career & Technical Center" } // Multi-School District Owned
        };

        #endregion Schools

        #region DistrictSchools

        public static List<DistrictSchool> DistrictSchools = new List<DistrictSchool>
        {
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Austintown Local School District"].Id, SchoolId = SchoolDictionary["Austintown Fitch High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Bloomfield-Mespo Local School District"].Id, SchoolId = SchoolDictionary["Bloomfield Middle/High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Bloomfield-Mespo Local School District"].Id, SchoolId = SchoolDictionary["Mesopatamia Elementary"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Bristol Local School District"].Id, SchoolId = SchoolDictionary["Bristol Elementary"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Bristol Local School District"].Id, SchoolId = SchoolDictionary["Bristol Middle & High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Brookfield Local School District"].Id, SchoolId = SchoolDictionary["Brookfield Elementary School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Brookfield Local School District"].Id, SchoolId = SchoolDictionary["Brookfield Middle School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Brookfield Local School District"].Id, SchoolId = SchoolDictionary["Brookfield High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Brookfield Local School District"].Id, SchoolId = SchoolDictionary["Trumbull Career & Technical Center"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Champion Local School District"].Id, SchoolId = SchoolDictionary["Central Elementary"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Champion Local School District"].Id, SchoolId = SchoolDictionary["Champion High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Champion Local School District"].Id, SchoolId = SchoolDictionary["Champion Middle School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Girard City School District"].Id, SchoolId = SchoolDictionary["Girard High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Girard City School District"].Id, SchoolId = SchoolDictionary["Girard Intermediate"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Girard City School District"].Id, SchoolId = SchoolDictionary["Girard Junior High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Girard City School District"].Id, SchoolId = SchoolDictionary["Prospect Elementary"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Girard City School District"].Id, SchoolId = SchoolDictionary["Trumbull Career & Technical Center"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Howland Local School District"].Id, SchoolId = SchoolDictionary["Glen Primary School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Howland Local School District"].Id, SchoolId = SchoolDictionary["H.C. Mines Elementary"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Howland Local School District"].Id, SchoolId = SchoolDictionary["North Road Intermediate"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Howland Local School District"].Id, SchoolId = SchoolDictionary["Howland High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Howland Local School District"].Id, SchoolId = SchoolDictionary["Howland Middle School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Howland Local School District"].Id, SchoolId = SchoolDictionary["Springs Primary School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Hubbard Exempted Village School District"].Id, SchoolId = SchoolDictionary["Hubbard Elementary School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Hubbard Exempted Village School District"].Id, SchoolId = SchoolDictionary["Hubbard High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = DistrictDictionary["Hubbard Exempted Village School District"].Id, SchoolId = SchoolDictionary["Hubbard Middle School"].Id, StartDate = DateTime.UtcNow }
        };

        #endregion DistrictSchools

        #region Students

        public static List<Student> Students = new List<Student>
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

        #endregion Students

        #region SchoolStudents

        public static List<SchoolStudent> SchoolStudents = new List<SchoolStudent>
        {
            new SchoolStudent
            {
                DateCreated = DateTime.UtcNow,
                GradeLevel = "9",
                Id = Guid.NewGuid(),
                RegistrationDate = DateTime.UtcNow,
                SchoolId = SchoolDictionary["Austintown Fitch High School"].Id,
                StudentId = Students[0].Id
            },
            new SchoolStudent
            {
                DateCreated = DateTime.UtcNow,
                GradeLevel = "9",
                Id = Guid.NewGuid(),
                RegistrationDate = DateTime.UtcNow,
                SchoolId = SchoolDictionary["Bloomfield Middle/High School"].Id,
                StudentId = Students[1].Id
            },
            new SchoolStudent
            {
                DateCreated = DateTime.UtcNow,
                GradeLevel = "9",
                Id = Guid.NewGuid(),
                RegistrationDate = DateTime.UtcNow,
                SchoolId = SchoolDictionary["Bloomfield Middle/High School"].Id,
                StudentId = Students[2].Id
            },
            new SchoolStudent
            {
                DateCreated = DateTime.UtcNow,
                GradeLevel = "9",
                Id = Guid.NewGuid(),
                RegistrationDate = DateTime.UtcNow,
                SchoolId = SchoolDictionary["Girard High School"].Id,
                StudentId = Students[3].Id
            },
            new SchoolStudent
            {
                DateCreated = DateTime.UtcNow,
                GradeLevel = "9",
                Id = Guid.NewGuid(),
                RegistrationDate = DateTime.UtcNow,
                SchoolId = SchoolDictionary["Girard High School"].Id,
                StudentId = Students[4].Id
            },
            new SchoolStudent
            {
                DateCreated = DateTime.UtcNow,
                GradeLevel = "9",
                Id = Guid.NewGuid(),
                RegistrationDate = DateTime.UtcNow,
                SchoolId = SchoolDictionary["Girard High School"].Id,
                StudentId = Students[5].Id
            },
            new SchoolStudent
            {
                DateCreated = DateTime.UtcNow,
                GradeLevel = "9",
                Id = Guid.NewGuid(),
                RegistrationDate = DateTime.UtcNow,
                SchoolId = SchoolDictionary["Girard High School"].Id,
                StudentId = Students[6].Id
            }
        };

        #endregion SchoolStudents

        #region Roles

        private static Dictionary<string, Role> _roleDictionary;
        public static Dictionary<string, Role> RoleDictionary
        {
            get
            {
                if (_roleDictionary == null)
                {
                    _roleDictionary = new Dictionary<string, Role>();
                    foreach (var obj in Roles)
                    {
                        _roleDictionary[obj.Name] = obj;
                    }
                }
                return _roleDictionary;
            }
            set { _roleDictionary = value; }
        }
        public static List<Role> Roles = new List<Role>
        {
            new Role { Id = Guid.NewGuid(), Name = "System Administrator", Description = "Total access to all other roles", DateCreated = DateTime.UtcNow },
            new Role { Id = Guid.NewGuid(), Name = "Can Create District Information", Description = "Can Create District Information", DateCreated = DateTime.UtcNow },
            new Role { Id = Guid.NewGuid(), Name = "Can Read District Information", Description = "Can Read District Information", DateCreated = DateTime.UtcNow },
            new Role { Id = Guid.NewGuid(), Name = "Can Update District Information", Description = "Can View District Information", DateCreated = DateTime.UtcNow },
            new Role { Id = Guid.NewGuid(), Name = "Can Delete District Information", Description = "Can Delete District Information", DateCreated = DateTime.UtcNow },
            new Role { Id = Guid.NewGuid(), Name = "Can Create School Information", Description = "Can Create School Information", DateCreated = DateTime.UtcNow },
            new Role { Id = Guid.NewGuid(), Name = "Can Read School Information", Description = "Can Read School Information", DateCreated = DateTime.UtcNow },
            new Role { Id = Guid.NewGuid(), Name = "Can Update School Information", Description = "Can View School Information", DateCreated = DateTime.UtcNow },
            new Role { Id = Guid.NewGuid(), Name = "Can Delete School Information", Description = "Can Delete School Information", DateCreated = DateTime.UtcNow },
            new Role { Id = Guid.NewGuid(), Name = "Can Create Student Information", Description = "Can Create Student Information", DateCreated = DateTime.UtcNow },
            new Role { Id = Guid.NewGuid(), Name = "Can Read Student Information", Description = "Can Read Student Information", DateCreated = DateTime.UtcNow },
            new Role { Id = Guid.NewGuid(), Name = "Can Update Student Information", Description = "Can View Student Information", DateCreated = DateTime.UtcNow },
            new Role { Id = Guid.NewGuid(), Name = "Can Delete Student Information", Description = "Can Delete Student Information", DateCreated = DateTime.UtcNow }
        };

        #endregion Roles

        #region Users

        private static Dictionary<string, User> _userDictionary;
        public static Dictionary<string, User> UserDictionary
        {
            get
            {
                if (_userDictionary == null)
                {
                    _userDictionary = new Dictionary<string, User>();
                    foreach (var obj in Users)
                    {
                        _userDictionary[obj.EmailAddress] = obj;
                    }
                }
                return _userDictionary;
            }
            set { _userDictionary = value; }
        }
        public static List<User> Users = new List<User>
        {
            new User
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.UtcNow,
                EmailAddress = "CostarellaMike@gmail.com",
                FirstName = "Mike",
                IsActive = true,
                LastName = "Costarella",
                MiddleName = "A.",
                UserName = "MikeCostarella"
            },
            new User
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.UtcNow,
                EmailAddress = "JoePrincipal@ghs.com",
                FirstName = "Joe",
                IsActive = true,
                LastName = "Principal",
                MiddleName = "L.",
                UserName = "JoePrincipal"
            }

        };

        #endregion Users

        #region UserRoles

        public static List<UserRole> UserRoles = new List<UserRole>
        {
            new UserRole
            {
                Id = Guid.NewGuid(),
                RoleId = RoleDictionary["System Administrator"].Id,
                UserId = UserDictionary["CostarellaMike@gmail.com"].Id
            }
        };

        #endregion UserRoles

        #region Groups

        private static Dictionary<string, Group> _groupDictionary;
        public static Dictionary<string, Group> GroupDictionary
        {
            get
            {
                if (_groupDictionary == null)
                {
                    _groupDictionary = new Dictionary<string, Group>();
                    foreach (var obj in Groups)
                    {
                        _groupDictionary[obj.Name] = obj;
                    }
                }
                return _groupDictionary;
            }
            set { _groupDictionary = value; }
        }
        public static List<Group> Groups = new List<Group>
        {
            new Group { Id = Guid.NewGuid(), Name = "Girard High School Staff", Description = "Staff members of Girard High School", DateCreated = DateTime.UtcNow }
        };

        #endregion Groups

        #region GroupRoles

        public static List<GroupRole> GroupRoles = new List<GroupRole>()
        {
            new GroupRole { Id = Guid.NewGuid(), GroupId = GroupDictionary["Girard High School Staff"].Id, RoleId = RoleDictionary["Can Read District Information"].Id },
            new GroupRole { Id = Guid.NewGuid(), GroupId = GroupDictionary["Girard High School Staff"].Id, RoleId = RoleDictionary["Can Read School Information"].Id },
            new GroupRole { Id = Guid.NewGuid(), GroupId = GroupDictionary["Girard High School Staff"].Id, RoleId = RoleDictionary["Can Read Student Information"].Id }
        };

        #endregion GroupRoles

        #region GroupUsers

        public static List<GroupUser> GroupUsers = new List<GroupUser>
        {
            new GroupUser { Id = Guid.NewGuid(), GroupId = GroupDictionary["Girard High School Staff"].Id, UserId = UserDictionary["JoePrincipal@ghs.com"].Id, DateCreated = DateTime.UtcNow }
        };

        #endregion GroupUsers
    }
}
