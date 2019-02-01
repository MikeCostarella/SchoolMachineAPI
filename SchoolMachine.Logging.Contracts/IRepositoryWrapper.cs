using SchoolMachine.Contracts.EntityRepositories;

namespace SchoolMachine.Contracts
{
    public interface IRepositoryWrapper
    {
        ISchoolRepository School { get; }

        IStudentRepository Student { get; }

        ISchoolStudentRepository SchoolStudent { get; }
    }
}
