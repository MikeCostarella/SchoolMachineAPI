using SchoolMachine.Contracts.EntityRepositories;

namespace SchoolMachine.Contracts
{
    public interface IRepositoryWrapper
    {
        IDistrictRepository District { get; set; }

        IDistrictSchoolRepository DistrictSchool { get; set; }

        ISchoolRepository School { get; set; }

        IStudentRepository Student { get; set; }

        ISchoolStudentRepository SchoolStudent { get; set; }
    }
}
