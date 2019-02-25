using SchoolMachine.Contracts.EntityRepositories;

namespace SchoolMachine.Contracts
{
    public interface IRepositoryWrapper
    {
        ISchoolRepository School { get; set; }

        IStudentRepository Student { get; set; }

        ISchoolStudentRepository SchoolStudent { get; set; }
    }
}
