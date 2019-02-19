using Microsoft.AspNetCore.Mvc;
using SchoolMachine.Contracts;
using SchoolMachine.DataAccess.Entities.SchoolData.Models;
using System;

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
        private IRepositoryWrapper _repositoryWrapper;

        #endregion Private Variables

        #region Constructors

        public SchoolStudentController(ILoggerManager loggerManager, IRepositoryWrapper repositoryWrapper)
        {
            _loggerManager = loggerManager;
            _repositoryWrapper = repositoryWrapper;
        }

        #endregion Constructors

        #region Actions

        /// <summary>
        /// Gets all SchoolStudent objects from the data repository
        /// </summary>
        /// <returns>IEnumerable of SchoolStudent(s) </returns>
        [HttpGet]
        public IActionResult GetAllSchoolStudents()
        {
            try
            {
                var schoolStudents = _repositoryWrapper.SchoolStudent.GetAllSchoolStudents();

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
        [ProducesResponseType(201, Type = typeof(SchoolStudent))]
        [ProducesResponseType(400)]
        public IActionResult GetSchoolStudentById(Guid id)
        {
            try
            {
                var school = _repositoryWrapper.SchoolStudent.GetSchoolStudentById(id);

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
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public void Post([FromBody] SchoolStudent schoolStudent)
        {
        }

        /// <summary>
        /// Updates a SchoolStudent object in the data store.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="schoolStudent"></param>
        [HttpPut("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public void Put(int id, [FromBody] SchoolStudent schoolStudent)
        {
        }

        /// <summary>
        /// Deletes a SchoolStudent object form the data repository
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }

        #endregion Actions
    }
}
