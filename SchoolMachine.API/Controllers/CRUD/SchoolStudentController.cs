using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.Contracts;
using SchoolMachine.DataAccess.Entities.SchoolData.Models;
using System;
using System.Threading.Tasks;

namespace SchoolMachine.API.Controllers.CRUD
{
    /// <summary>
    /// Provides CRUD functionality for the SchoolStudent object
    /// </summary>
    [Route("api/schoolstudent")]
    [ApiController]
    public class SchoolStudentController : ControllerBase
    {
        #region Private Variables

        private ILoggerManager _loggerManager;
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;

        #endregion Private Variables

        #region Constructors

        public SchoolStudentController(ILoggerManager loggerManager, IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _loggerManager = loggerManager;
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        #endregion Constructors

        #region Actions

        /// <summary>
        /// Gets all SchoolStudent objects from the data repository
        /// </summary>
        /// <returns>IEnumerable of SchoolStudent(s) </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllSchoolStudents()
        {
            try
            {
                var schoolStudents = await _repositoryWrapper.SchoolStudent.GetAllSchoolStudents();
                _loggerManager.LogInfo($"Returned all SchoolStudents from database.");
                return Ok(schoolStudents);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside GetAllSchoolStudents action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Gets a SchoolStudent object from the data repository by its unique id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchoolStudentById(Guid id)
        {
            try
            {
                var school = await _repositoryWrapper.SchoolStudent.GetSchoolStudentById(id);

                if (school.Id.Equals(Guid.Empty))
                {
                    _loggerManager.LogError($"SchoolStudent with id: {id}, was not found in db.");
                    return NotFound();
                }
                else
                {
                    _loggerManager.LogInfo($"Returned SchoolStudent with id: {id}");
                    return Ok(school);
                }
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside GetSchoolStudentById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Creates and saves a new SchoolStudent record in the data 
        /// </summary>
        /// <param name="schoolStudent"></param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SchoolStudent schoolStudent)
        {
            return Ok();
        }

        /// <summary>
        /// Updates a SchoolStudent object in the data store.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="schoolStudent"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SchoolStudent schoolStudent)
        {
            return Ok();
        }

        /// <summary>
        /// Deletes a SchoolStudent object form the data repository
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok();
        }

        #endregion Actions
    }
}
