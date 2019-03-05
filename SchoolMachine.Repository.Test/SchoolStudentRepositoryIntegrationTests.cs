﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolMachine.DataAccess.Entities.SeedData;
using SchoolMachine.Repository.Entities;
using SchoolMachine.Repository.Test.Base;
using System.Linq;

namespace SchoolMachine.Repository.Test
{
    [TestClass]
    public class SchoolStudentRepositoryIntegrationTests : BaseRepositoryIntegrationTests
    {
        #region Setup/Teardown

        [ClassInitialize]
        public static void TestClassSetup(TestContext context)
        {
            BaseTestClassSetup(context);
        }

        [ClassCleanup]
        public static void TestClassCleanup()
        {
            BaseTestClassCleanup();
        }

        #endregion Setup/Teardown

        #region Tests

        [TestMethod]
        public void StudentsBySchool()
        {
            // Setup
            var schoolStudentRepository = new SchoolStudentRepository(SchoolMachineContext);
            // Test Logic
            var students = schoolStudentRepository.StudentsBySchool(DataSeeder.Schools[0].Id).Result;
            // Assertions
            var expectedStudents = DataSeeder.SchoolStudents.Where(schoolStudent => schoolStudent.SchoolId == DataSeeder.Schools[0].Id);
            Assert.IsTrue(students.Count() > expectedStudents.Count(), string.Format("DataSeeder has {0} SchoolStudents and only found {1}", expectedStudents.Count(), students.Count()));
        }

        #endregion Tests
    }
}
