using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.Contracts;
using SchoolMachine.DataAccess.Entities.Extensions;
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

        // GET: api/Student/615226ff-f759-4dc9-84ce-f27228a1252e
        [HttpGet("{id}", Name ="GetStudentById")]
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
        public IActionResult CreateStudent([FromBody] Student student)
        {
            try
            {
                if (student.IsObjectNull())
                {
                    _loggerManager.LogError("Student object sent from client is null.");
                    return BadRequest("Student object is null");
                }

                if (!ModelState.IsValid)
                {
                    _loggerManager.LogError("Invalid student object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _repositoryWrapper.Student.CreateStudent(student);

                return CreatedAtRoute("StudentById", new { id = student.Id }, student);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside CreateStudent action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Student/615226ff-f759-4dc9-84ce-f27228a1252e
        [HttpPut("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult UpdateStudent(Guid id, [FromBody] Student student)
        {
            try
            {
                if (student.IsObjectNull())
                {
                    _loggerManager.LogError("Student object sent from client is null.");
                    return BadRequest("Student object is null");
                }

                if (!ModelState.IsValid)
                {
                    _loggerManager.LogError("Invalid student object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbStudent = _repositoryWrapper.Student.GetStudentById(id);
                if (dbStudent.IsEmptyObject())
                {
                    _loggerManager.LogError($"School with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repositoryWrapper.Student.UpdateStudent(dbStudent, student);

                return NoContent();
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside UpdateStudent action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/ApiWithActions/615226ff-f759-4dc9-84ce-f27228a1252e
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(Guid id)
        {
            try
            {
                var student = _repositoryWrapper.Student.GetStudentById(id);
                if (student.IsEmptyObject())
                {
                    _loggerManager.LogError($"School with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                if (_repositoryWrapper.SchoolStudent.SchoolStudentsByStudent(id).Any())
                {
                    _loggerManager.LogError($"Cannot delete student with id: {id}. It has related schoolStudents. Delete those schoolStudents first");
                    return BadRequest("Cannot delete student. It has related schoolStudents. Delete those schoolStudents first");
                }

                _repositoryWrapper.Student.DeleteStudent(student);

                return NoContent();
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside DeleteSchool action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion Action Methods
    }
}
