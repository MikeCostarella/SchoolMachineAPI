using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using SchoolMachine.DataAccess.Entities.SeedData;
using SchoolMachine.Testing.API.Base;

namespace SchoolMachine.Testing.API.Controllers.CRUD
{

    /// <summary>
    /// Performs integration tests on StudentController action methods
    /// </summary>
    [TestClass]
    public class StudentControllerIntegrationTests : SchoolMachineApiIntegrationTestBase
    {
        // ToDo: Fill in remaining test logic
        #region Action Tests

        [TestMethod]
        public void GetAllStudents()
        {
            Test_GetAllObjects<Student>("api/student/", DataSeeder.StudentSeeder.Objects);
        }

        [TestMethod]
        public void GetStudentById()
        {
            Test_GetNamedEntityById<Student>("api/student/");
        }

        [TestMethod]
        public void CreateStudent()
        {

        }

        [TestMethod]
        public void UpdateStudent()
        {

        }

        [TestMethod]
        public void DeleteStudent()
        {

        }

        #endregion Action Methods
    }
}
