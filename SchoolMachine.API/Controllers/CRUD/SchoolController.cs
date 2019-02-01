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
    [Route("api/school")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private ILoggerManager _loggerManager;
        private IRepositoryWrapper _repositoryWrapper;

        public SchoolController(ILoggerManager loggerManager, IRepositoryWrapper repositoryWrapper)
        {
            _loggerManager = loggerManager;
            _repositoryWrapper = repositoryWrapper;
        }

        // GET: api/School
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

        // GET: api/Student/5
        [HttpGet("{id}")]
        [ProducesResponseType(201, Type = typeof(School))]
        [ProducesResponseType(400)]
        public IActionResult GetSchoolById(Guid id)
        {
            try
            {
                var school = _repositoryWrapper.School.GetSchoolById(id);

                if (school.Id.Equals(Guid.Empty))
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