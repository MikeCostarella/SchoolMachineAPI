using SchoolMachine.Contracts.EntityRepositories;

namespace SchoolMachine.Contracts
{
    public interface IRepositoryWrapper
    {
        ICountryRepository Country { get; set; }

        IDistrictRepository District { get; set; }

        IDistrictSchoolRepository DistrictSchool { get; set; }

        ISchoolRepository School { get; set; }

        IStudentRepository Student { get; set; }

        ISchoolStudentRepository SchoolStudent { get; set; }

        IStateRepository State { get; set; }

    }
}
