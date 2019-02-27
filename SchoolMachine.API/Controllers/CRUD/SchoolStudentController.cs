using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.API.Controllers.Base;
using SchoolMachine.API.Dtos;
using SchoolMachine.Contracts;
using SchoolMachine.DataAccess.Entities.Extensions;
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
    public class SchoolStudentController : ControllerBaseSchoolMachine
    {
        #region Constructors

        public SchoolStudentController(ILoggerManager loggerManager, IMapper mapper, IRepositoryWrapper repositoryWrapper)
            : base(loggerManager, mapper, repositoryWrapper)
        {
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
        /// Creates and saves a new SchoolStudent record in the data repository
        /// </summary>
        /// <param name="schoolStudentDto"></param>
        [HttpPost("CreateSchoolStudent", Name = "CreateSchoolStudent")]
        public async Task<IActionResult> CreateSchoolStudent([FromQuery] SchoolStudentDto schoolStudentDto)
        {
            try
            {
                if (schoolStudentDto == null)
                {
                    _loggerManager.LogError("schoolStudentDto object sent from client is null.");
                    return BadRequest("schoolStudentDto object is null");
                }
                if (!ModelState.IsValid)
                {
                    _loggerManager.LogError("Invalid schoolStudentDto object sent from client.");
                    return BadRequest("Invalid schoolStudentDto model object");
                }
                var schoolStudent = _mapper.Map<SchoolStudent>(schoolStudentDto);
                await _repositoryWrapper.SchoolStudent.CreateSchoolStudent(schoolStudent);
                if (schoolStudent.IsEmptyObject())
                {
                    _loggerManager.LogError($"Save operation failed inside CreateSchoolStudent action");
                    return StatusCode(500, "Internal server error while saving School ");
                }
                var dbObject = await _repositoryWrapper.SchoolStudent.GetSchoolStudentById(schoolStudent.Id);
                return Ok(dbObject);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside CreateSchoolStudent action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Updates a SchoolStudent object in the data store.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="schoolStudentDto"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchoolStudent(Guid id, [FromQuery] SchoolStudentDto schoolStudentDto)
        {
            try
            {
                if (schoolStudentDto == null)
                {
                    _loggerManager.LogError("SchoolStudentDto object sent from client is null.");
                    return BadRequest("SchoolStudentDto object is null");
                }
                if (!ModelState.IsValid)
                {
                    _loggerManager.LogError("Invalid SchoolStudentDto object sent from client.");
                    return BadRequest("Invalid SchoolStudentDto model object");
                }
                var dbSchoolStudentDto = await _repositoryWrapper.SchoolStudent.GetSchoolStudentById(id);
                if (dbSchoolStudentDto.IsEmptyObject())
                {
                    _loggerManager.LogError($"School with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                var schoolStudent = _mapper.Map<SchoolStudent>(schoolStudentDto);
                await _repositoryWrapper.SchoolStudent.UpdateSchoolStudent(dbSchoolStudentDto, schoolStudent);
                return NoContent();
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside UpdateSchoolStudent action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Deletes a SchoolStudent object form the data repository
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchoolStudent(Guid id)
        {
            try
            {
                var schoolStudent = await _repositoryWrapper.SchoolStudent.GetSchoolStudentById(id);
                if (schoolStudent.IsEmptyObject())
                {
                    _loggerManager.LogError($"SchoolStudent with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                await _repositoryWrapper.SchoolStudent.DeleteSchoolStudent(schoolStudent);
                return NoContent();
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside DeleteSchoolStudent action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion Actions
    }
}
