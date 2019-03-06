using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using SchoolMachine.DataAccess.Entities.Models.Security;
using SchoolMachine.DataAccess.Entities.SchoolData.Models;
using System;
using System.Collections.Generic;

namespace SchoolMachine.DataAccess.Entities.SeedData
{
    public static class DataSeeder
    {
        #region Roles

        private static Dictionary<string, Role> _roleDictionary;
        public static Dictionary<string, Role> RoleDictionary {
            get {
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
            new Role { Id = Guid.NewGuid(), Name = "System Administrator", Description = "Total access to all other roles" }
        };

        #endregion Roles

        #region SchoolDistricts

        private static Dictionary<string, District> _schoolDistrictDictionary;
        public static Dictionary<string, District> SchoolDistrictDictionary
        {
            get
            {
                if (_schoolDistrictDictionary == null)
                {
                    _schoolDistrictDictionary = new Dictionary<string, District>();
                    foreach (var obj in SchoolDistricts)
                    {
                        _schoolDistrictDictionary[obj.Name] = obj;
                    }
                }
                return _schoolDistrictDictionary;
            }
            set { _schoolDistrictDictionary = value; }
        }
        public static List<District> SchoolDistricts = new List<District>
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

        #endregion SchoolDistricts

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
            new School { Id = Guid.NewGuid(), Name = "Girard High School" },
            new School { Id = Guid.NewGuid(), Name = "Girard Intermediate" },
            new School { Id = Guid.NewGuid(), Name = "Girard Junior High School" },
            new School { Id = Guid.NewGuid(), Name = "Glen Primary School" }, // Howland Local School District
            new School { Id = Guid.NewGuid(), Name = "H.C. Mines Elementary" }, // Howland Local School District
            new School { Id = Guid.NewGuid(), Name = "Howland High School" },
            new School { Id = Guid.NewGuid(), Name = "Howland Middle School" },
            new School { Id = Guid.NewGuid(), Name = "Liberty High School" },
            new School { Id = Guid.NewGuid(), Name = "Mesopatamia Elementary" }, // Bloomfield-Mespo Local School District
            new School { Id = Guid.NewGuid(), Name = "North Road Intermediate" }, // Howland Local School District
            new School { Id = Guid.NewGuid(), Name = "Prospect Elementary" }, // Girard City School District
            new School { Id = Guid.NewGuid(), Name = "Springs Primary School" }, // Howland Local School District
        };

        #endregion Schools

        #region SchoolDistrictSchools

        public static List<DistrictSchool> SchoolDistrictSchools = new List<DistrictSchool>
        {
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = SchoolDistrictDictionary["Austintown Local School District"].Id, SchoolId = SchoolDictionary["Austintown Fitch High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = SchoolDistrictDictionary["Bloomfield-Mespo Local School District"].Id, SchoolId = SchoolDictionary["Bloomfield Middle/High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = SchoolDistrictDictionary["Bloomfield-Mespo Local School District"].Id, SchoolId = SchoolDictionary["Mesopatamia Elementary"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = SchoolDistrictDictionary["Bristol Local School District"].Id, SchoolId = SchoolDictionary["Bristol Elementary"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = SchoolDistrictDictionary["Bristol Local School District"].Id, SchoolId = SchoolDictionary["Bristol Middle & High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = SchoolDistrictDictionary["Brookfield Local School District"].Id, SchoolId = SchoolDictionary["Brookfield Elementary School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = SchoolDistrictDictionary["Brookfield Local School District"].Id, SchoolId = SchoolDictionary["Brookfield Middle School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = SchoolDistrictDictionary["Brookfield Local School District"].Id, SchoolId = SchoolDictionary["Brookfield High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = SchoolDistrictDictionary["Champion Local School District"].Id, SchoolId = SchoolDictionary["Central Elementary"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = SchoolDistrictDictionary["Champion Local School District"].Id, SchoolId = SchoolDictionary["Champion High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = SchoolDistrictDictionary["Champion Local School District"].Id, SchoolId = SchoolDictionary["Champion Middle School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = SchoolDistrictDictionary["Girard City School District"].Id, SchoolId = SchoolDictionary["Girard High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = SchoolDistrictDictionary["Girard City School District"].Id, SchoolId = SchoolDictionary["Girard Intermediate"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = SchoolDistrictDictionary["Girard City School District"].Id, SchoolId = SchoolDictionary["Girard Junior High School"].Id, StartDate = DateTime.UtcNow },
            new DistrictSchool { Id = Guid.NewGuid(), DistrictId = SchoolDistrictDictionary["Girard City School District"].Id, SchoolId = SchoolDictionary["Prospect Elementary"].Id, StartDate = DateTime.UtcNow },
        };

        #endregion SchoolDistrictSchools

        #region Students

        public static List<Student> Students = new List<Student>
        {
            new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/01/2005"), FirstName = "John", MiddleName = "Alfred", LastName = "Abott" },
            new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("11/10/2005"), FirstName = "Ann", MiddleName = "Grace", LastName = "Smith" },
            new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("09/01/2004"), FirstName = "Bill", MiddleName = "Anthony", LastName = "Kriter" },
            new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("01/01/2005"), FirstName = "Sara", MiddleName = "Lynn", LastName = "Carter" },
            new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/01/2006"), FirstName = "John", MiddleName = "Dudley", LastName = "Timkin" },
            new Student { Id = Guid.NewGuid(), BirthDate = DateTime.Parse("12/10/2006"), FirstName = "Abby", MiddleName = "Darla", LastName = "Smart" }
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
            }
        };

        #endregion SchoolStudents

        #region Users

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

        #endregion Users
    }
}
