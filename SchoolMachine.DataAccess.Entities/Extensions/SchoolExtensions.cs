using SchoolMachine.DataAccess.Entities.Models;

namespace SchoolMachine.DataAccess.Entities.Extensions
{
    public static class SchoolExtensions
    {
        public static void Map(this School dbSchool, School school)
        {
            dbSchool.Name = school.Name;
        }
    }
}
