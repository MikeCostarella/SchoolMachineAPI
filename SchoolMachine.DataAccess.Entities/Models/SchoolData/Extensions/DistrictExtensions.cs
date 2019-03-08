namespace SchoolMachine.DataAccess.Entities.Models.SchoolData.Extensions
{
    public static class DistrictExtensions
    {
        // ToDo: Replace this with automapper call
        public static void Map(this District dbDistrict, District district)
        {
            dbDistrict.Name = district.Name;
        }
    }
}
