using SchoolMachine.DataAccess.Entities.SchoolData.Models;

namespace SchoolMachine.DataAccess.Entities.Models.SchoolData.Extensions
{
    public static class StudentExtensions
    {

        // ToDo: Replace this with automapper call
        public static void Map(this Student dbStudent, Student student)
        {
            dbStudent.BirthDate = student.BirthDate;
            dbStudent.FirstName = student.FirstName;
            dbStudent.LastName = student.LastName;
            dbStudent.MiddleName = student.MiddleName;
        }

    }
}
