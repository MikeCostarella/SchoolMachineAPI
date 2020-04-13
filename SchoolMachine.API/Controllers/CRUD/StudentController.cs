using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.API.Controllers.Base;
using SchoolMachine.API.Dtos;
using SchoolMachine.Contracts;
using SchoolMachine.DataAccess.Entities.Extensions.Base;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;

namespace SchoolMachine.API.Controllers
{
    /// <summary>
    /// Provides CRUD functionality for the Student object
    /// </summary>
    [ApiController]
    [Route("api/student")]
    [Produces("application/json")]
    public class StudentController : ControllerBaseSchoolMachine
    {
        #region Constructors

        public StudentController(ILoggerManager loggerManager, IMapper mapper, IRepositoryWrapper repositoryWrapper)
            : base(loggerManager, mapper, repositoryWrapper)
        {
        }

        #endregion Constructors

        #region Actions

        /// <summary>
        /// Gets all students from the data repository
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var students = await _repositoryWrapper.Student.GetAllStudents();
                _loggerManager.LogInfo($"Returned all students from database.");
                return Ok(students);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside GetAllStudents action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Gets a Student from the data repository by its unique id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name ="GetStudentById")]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            try
            {
                var student = await _repositoryWrapper.Student.GetStudentById(id);
                if (student.Id.Equals(Guid.Empty))
                {
                    _loggerManager.LogError($"Student with id: {id}, was not found in db.");
                    return NotFound();
                }
                else
                {
                    _loggerManager.LogInfo($"Returned student with id: {id}");
                    return Ok(student);
                }
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside GetSTudentById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Gets School objects from the data repository by a unique Student id
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet("GetSchoolsByStudentId", Name = "GetSchoolsByStudentId")]
        public async Task<IActionResult> GetSchoolsByStudentId(Guid studentId)
        {
            try
            {
                var schools = await _repositoryWrapper.Student.GetSchoolsByStudentId(studentId);
                _loggerManager.LogInfo($"Returned { schools.Count() } SchoolStudents from repository for Student { studentId }.");
                return Ok(schools);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside GetSchoolsByStudentId action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Creates and saves a student to the data repository based off a unique name (for now)
        /// </summary>
        /// <param name="studentDto"></param>
        /// <returns></returns>
        [HttpPost("CreateStudent", Name = "CreateStudent")]
        public async Task<IActionResult> CreateStudent([FromBody] StudentDto studentDto)
        {
            try
            {
                if (studentDto == null)
                {
                    _loggerManager.LogError("StudentDto sent from client is null.");
                    return BadRequest("StudentDto is null");
                }
                if (!ModelState.IsValid)
                {
                    _loggerManager.LogError("Invalid StudentDto sent from client.");
                    return BadRequest("Invalid StudentDto model object");
                }
                var student = _mapper.Map<Student>(studentDto);
                await _repositoryWrapper.Student.CreateStudent(student);
                if (student.IsEmptyObject())
                {
                    _loggerManager.LogError($"Save operation failed inside CreateStudent action");
                    return StatusCode(500, "Internal server error while saving Student ");
                }
                var dbSchool = await _repositoryWrapper.Student.GetStudentById(student.Id);
                return Ok(dbSchool);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside CreateStudent action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Updates a student in the respository identified by its unique id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="studentDto"></param>
        /// <returns></returns>
        [HttpPut("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent([FromQuery] Guid id, [FromBody] StudentDto studentDto)
        {
            try
            {
                if (studentDto == null)
                {
                    _loggerManager.LogError("StudentDto sent from client is null.");
                    return BadRequest("StudentDto is null");
                }
                if (!ModelState.IsValid)
                {
                    _loggerManager.LogError("Invalid StudentDto sent from client.");
                    return BadRequest("Invalid model object");
                }
                var student = _mapper.Map<Student>(studentDto);
                var dbStudent = await _repositoryWrapper.Student.GetStudentById(id);
                if (dbStudent.IsEmptyObject())
                {
                    _loggerManager.LogError($"Student with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                await _repositoryWrapper.Student.UpdateStudent(dbStudent, student);
                return NoContent();
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside UpdateStudent action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Deletes a student from the data repository identified by its unique id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            try
            {
                var student = await _repositoryWrapper.Student.GetStudentById(id);
                if (student.IsEmptyObject())
                {
                    _loggerManager.LogError($"School with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                if ((await _repositoryWrapper.SchoolStudent.SchoolStudentsByStudent(id)).Any())
                {
                    _loggerManager.LogError($"Cannot delete student with id: {id}. It has related schoolStudents. Delete those schoolStudents first");
                    return BadRequest("Cannot delete student. It has related schoolStudents. Delete those schoolStudents first");
                }
                await _repositoryWrapper.Student.DeleteStudent(student);
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
