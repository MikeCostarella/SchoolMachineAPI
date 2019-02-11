using SchoolMachine.DataAccess.Entities.SchoolData.Models;

namespace SchoolMachine.DataAccess.Entities.Extensions
{
    public static class StudentExtensions
    {
        public static void Map(this Student dbStudent, Student student)
        {
            dbStudent.BirthDate = student.BirthDate;
            dbStudent.FirstName = student.FirstName;
            dbStudent.LastName = student.LastName;
            dbStudent.MiddleName = student.MiddleName;
        }
    }
}
