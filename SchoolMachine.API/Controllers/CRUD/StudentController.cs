using System;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.Contracts;
using SchoolMachine.DataAccess.Entities.Models;

namespace SchoolMachine.API.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        #region Private Variables

        private ILoggerManager _loggerManager;
        private IRepositoryWrapper _repositoryWrapper;

        #endregion Private Variables

        #region Constructors

        public StudentController(ILoggerManager loggerManager, IRepositoryWrapper repositoryWrapper)
        {
            _loggerManager = loggerManager;
            _repositoryWrapper = repositoryWrapper;
        }

        #endregion Constructors

        #region Action Methods

        // GET: api/Student
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            try
            {
                var students = _repositoryWrapper.Student.GetAllStudents();

                _loggerManager.LogInfo($"Returned all students from database.");

                return Ok(students);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside GetAllStudents action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        [ProducesResponseType(201, Type = typeof(Student))]
        [ProducesResponseType(400)]
        public IActionResult GetStudentById(Guid id)
        {
            try
            {
                var student = _repositoryWrapper.Student.GetStudentById(id);

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

        // POST: api/Student
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public void Post([FromBody] Student value)
        {
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public void Put(int id, [FromBody] Student value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }

        #endregion Action Methods
    }
}
