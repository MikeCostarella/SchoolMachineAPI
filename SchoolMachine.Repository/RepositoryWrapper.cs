using SchoolMachine.Contracts;
using SchoolMachine.Contracts.EntityRepositories;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.Repository.Entities;

namespace SchoolMachine.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        #region Private Variables

        private RepositoryContext _repoContext;

        private ISchoolRepository _school;
        private ISchoolStudentRepository _schoolStudent;
        private IStudentRepository _student;

        #endregion Private Variables

        #region Repository Properties

        public ISchoolRepository School
        {
            get
            {
                if (_school == null)
                {
                    _school = new SchoolRepository(_repoContext);
                }

                return _school;
            }
        }

        public ISchoolStudentRepository SchoolStudent
        {
            get
            {
                if (_schoolStudent == null)
                {
                    _schoolStudent = new SchoolStudentRepository(_repoContext);
                }

                return _schoolStudent;
            }
        }

        public IStudentRepository Student
        {
            get
            {
                if (_student == null)
                {
                    _student = new StudentRepository(_repoContext);
                }

                return _student;
            }
        }

        #endregion Repository Properties

        #region Constructors
    
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        #endregion Constructors
    }
}
