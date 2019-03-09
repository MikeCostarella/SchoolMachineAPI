using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SchoolMachine.API.Helpers;
using SchoolMachine.API.UnitTests.Mocks;
using SchoolMachine.Contracts;
using SchoolMachine.Contracts.EntityRepositories;
using SchoolMachine.Repository;

namespace SchoolMachine.API.UnitTests.Base
{
    public class BaseControllerUnitTests
    {
        #region Protected Variables

        protected ILoggerManager _loggerManager = new MockLoggerManager();
        protected IMapper _mapper;
        protected MapperConfiguration _mapperConfiguration;
        protected IRepositoryWrapper _repositoryWrapper;

        #endregion Private Variables

        #region Initialization

        [TestInitialize]
        public void TestInitializer()
        {
            _mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<AutoMapperProfile>(); });
            _mapper = _mapperConfiguration.CreateMapper();
            _mapper = new Mapper(_mapperConfiguration);
            _repositoryWrapper = Mock.Of<RepositoryWrapper>();
            _repositoryWrapper.District = Mock.Of<IDistrictRepository>();
            _repositoryWrapper.DistrictSchool = Mock.Of<IDistrictSchoolRepository>();
            _repositoryWrapper.School = Mock.Of<ISchoolRepository>();
            _repositoryWrapper.SchoolStudent = Mock.Of<ISchoolStudentRepository>();
            _repositoryWrapper.Student = Mock.Of<IStudentRepository>();
        }

        #endregion Initialization
    }
}
