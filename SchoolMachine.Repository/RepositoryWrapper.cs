using SchoolMachine.Contracts;
using SchoolMachine.Contracts.EntityRepositories;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.Repository.Entities;

namespace SchoolMachine.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        #region Private Variables

        private SchoolMachineContext _repoContext;

        private ICountryRepository _country;
        private IDistrictRepository _district;
        private IDistrictSchoolRepository _districtSchool;
        private ISchoolRepository _school;
        private ISchoolStudentRepository _schoolStudent;
        private IStateRepository _state;
        private IStudentRepository _student;

        #endregion Private Variables

        #region Constructors

        public RepositoryWrapper(SchoolMachineContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public RepositoryWrapper()
        {
        }

        #endregion Constructors

        #region Repository Properties

        public ICountryRepository Country
        {
            get
            {
                if (_country == null)
                {
                    _country = new CountryRepository(_repoContext);
                }
                return _country;
            }
            set { _country = value; }
        }

        public IDistrictRepository District
        {
            get
            {
                if (_district == null)
                {
                    _district = new DistrictRepository(_repoContext);
                }

                return _district;
            }
            set { _district = value; }
        }

        public IDistrictSchoolRepository DistrictSchool
        {
            get
            {
                if (_districtSchool == null)
                {
                    _districtSchool = new DistrictSchoolRepository(_repoContext);
                }

                return _districtSchool;
            }
            set { _districtSchool = value; }
        }

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
            set { _school = value; }
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
            set { _schoolStudent = value; }
        }

        public IStateRepository State
        {
            get
            {
                if (_state == null)
                {
                    _state = new StateRepository(_repoContext);
                }
                return _state;
            }
            set { _state = value; }
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
            set { _student = value; }
        }

        #endregion Repository Properties
    }
}
