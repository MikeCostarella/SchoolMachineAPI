using SchoolMachine.DataAccess.Entities.SchoolData.Models;

namespace SchoolMachine.DataAccess.Entities.Models.SchoolData.Extensions
{
    public static class SchoolExtensions
    {
        // ToDo: Replace this with automapper call
        public static void Map(this School dbSchool, School school)
        {
            dbSchool.Name = school.Name;
        }
    }
}
