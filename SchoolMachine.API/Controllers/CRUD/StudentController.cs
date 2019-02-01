using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.Contracts;
using SchoolMachine.DataAccess.Entities.Models;

namespace SchoolMachine.API.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private ILoggerManager _loggerManager;
        private IRepositoryWrapper _repositoryWrapper;

        public StudentController(ILoggerManager loggerManager, IRepositoryWrapper repositoryWrapper)
        {
            _loggerManager = loggerManager;
            _repositoryWrapper = repositoryWrapper;
        }

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
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(201, Type = typeof(Student))]
        [ProducesResponseType(400)]
        public IActionResult Get(int id)
        {
            // TODO: Fill in call to business logic layer to get students
            return Ok(new Student());
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
        public void Delete(int id)
        {
        }
    }
}
