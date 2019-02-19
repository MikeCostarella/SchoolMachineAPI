using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.Contracts;
using SchoolMachine.DataAccess.Entities.Extensions;
using SchoolMachine.DataAccess.Entities.SchoolData.Models;

namespace SchoolMachine.API.Controllers
{
    /// <summary>
    /// Handles CRUD service operations for the school entity.
    /// </summary>
    [Route("api/school")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        #region Private Variables

        private ILoggerManager _loggerManager;
        private IRepositoryWrapper _repositoryWrapper;

        #endregion Private Variables

        #region Constructors

        public SchoolController(ILoggerManager loggerManager, IRepositoryWrapper repositoryWrapper)
        {
            _loggerManager = loggerManager;
            _repositoryWrapper = repositoryWrapper;
        }

        #endregion Constructors

        #region Actions
        /// <summary>
        /// Gets all schools from the data store
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllSchools()
        {
            try
            {
                var schools = _repositoryWrapper.School.GetAllSchools();

                _loggerManager.LogInfo($"Returned all schools from database.");

                return Ok(schools);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside GetAllSchools action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Geta a school by its guid id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name="GetSchoolById")]
        [ProducesResponseType(201, Type = typeof(School))]
        [ProducesResponseType(400)]
        public IActionResult GetSchoolById(Guid id)
        {
            try
            {
                var school = _repositoryWrapper.School.GetSchoolById(id);

                if (school.IsEmptyObject())
                {
                    _loggerManager.LogError($"School with id: {id}, was not found in db.");
                    return NotFound();
                }
                else
                {
                    _loggerManager.LogInfo($"Returned student with id: {id}");
                    return Ok(school);
                }
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside GetSchoolById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Stores a new school in the data store based on a unique name
        /// </summary>
        /// <param name="school"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult CreateSchool([FromBody] School school)
        {
            try
            {
                if (school.IsObjectNull())
                {
                    _loggerManager.LogError("School object sent from client is null.");
                    return BadRequest("School object is null");
                }

                if (!ModelState.IsValid)
                {
                    _loggerManager.LogError("Invalid school object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _repositoryWrapper.School.CreateSchool(school);

                return CreatedAtRoute("SchoolById", new { id = school.Id }, school);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside CreateSchool action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Updates a school object in the data store with identical id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="school"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult UpdateSchool(Guid id, [FromBody] School school)
        {
            try
            {
                if (school.IsObjectNull())
                {
                    _loggerManager.LogError("School object sent from client is null.");
                    return BadRequest("School object is null");
                }

                if (!ModelState.IsValid)
                {
                    _loggerManager.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbSchool = _repositoryWrapper.School.GetSchoolById(id);
                if (dbSchool.IsEmptyObject())
                {
                    _loggerManager.LogError($"School with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repositoryWrapper.School.UpdateSchool(dbSchool, school);

                return NoContent();
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside UpdateSchool action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Deletes a school by its unique id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}")]
        public IActionResult DeleteSchool(Guid id)
        {
            try
            {
                var school = _repositoryWrapper.School.GetSchoolById(id);
                if (school.IsEmptyObject())
                {
                    _loggerManager.LogError($"School with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                if (_repositoryWrapper.SchoolStudent.SchoolStudentsBySchool(id).Any())
                {
                    _loggerManager.LogError($"Cannot delete school with id: {id}. It has related schoolStudents. Delete those schoolStudents first");
                    return BadRequest("Cannot delete school. It has related schoolStudents. Delete those schoolStudents first");
                }

                _repositoryWrapper.School.DeleteSchool(school);

                return NoContent();
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside DeleteSchool action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion Actions
    }
}