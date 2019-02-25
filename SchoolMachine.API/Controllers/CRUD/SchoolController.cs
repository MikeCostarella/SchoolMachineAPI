﻿using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.API.Dtos;
using SchoolMachine.Contracts;
using SchoolMachine.DataAccess.Entities.Extensions;
using SchoolMachine.DataAccess.Entities.SchoolData.Models;

namespace SchoolMachine.API.Controllers
{
    /// <summary>
    /// Handles CRUD functionality for the school entity.
    /// </summary>
    [Route("api/school")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        #region Private Variables

        private ILoggerManager _loggerManager;
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;

        #endregion Private Variables

        #region Constructors

        public SchoolController(ILoggerManager loggerManager, IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _loggerManager = loggerManager;
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        #endregion Constructors

        #region Actions

        /// <summary>
        /// Gets all schools from the data store
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllSchools()
        {
            try
            {
                var schools = await _repositoryWrapper.School.GetAllSchools();
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
        /// Gets a school from the data respository by its unique id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name="GetSchoolById")]
        public async Task<IActionResult> GetSchoolById(Guid id)
        {
            try
            {
                var school = await _repositoryWrapper.School.GetSchoolById(id);
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
        /// Creates a new school in the data respository based on a unique name
        /// </summary>
        /// <param name="schoolDto"></param>
        /// <returns></returns>
        [HttpPost("CreateSchool", Name = "CreateSchool")]
        public async Task<IActionResult> CreateSchool([FromQuery] SchoolDto schoolDto)
        {
            try
            {
                if (schoolDto == null)
                {
                    _loggerManager.LogError("SchoolDto object sent from client is null.");
                    return BadRequest("SchoolDto object is null");
                }
                if (!ModelState.IsValid)
                {
                    _loggerManager.LogError("Invalid SchoolDto object sent from client.");
                    return BadRequest("Invalid SchoolDto model object");
                }
                var school = _mapper.Map<School>(schoolDto);
                await _repositoryWrapper.School.CreateSchool(school);
                return CreatedAtRoute("GetSchoolById", new { id = school.Id }, school);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside CreateSchool action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Updates a school in the data respository
        /// </summary>
        /// <param name="id"></param>
        /// <param name="schoolDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchool(Guid id, [FromQuery] SchoolDto schoolDto)
        {
            try
            {
                if (schoolDto == null)
                {
                    _loggerManager.LogError("SchoolDto object sent from client is null.");
                    return BadRequest("SchoolDto object is null");
                }
                if (!ModelState.IsValid)
                {
                    _loggerManager.LogError("Invalid SchoolDto object sent from client.");
                    return BadRequest("Invalid SchoolDto model object");
                }
                var dbSchool = await _repositoryWrapper.School.GetSchoolById(id);
                if (dbSchool.IsEmptyObject())
                {
                    _loggerManager.LogError($"School with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                var school = _mapper.Map<School>(schoolDto);
                await _repositoryWrapper.School.UpdateSchool(dbSchool, school);
                return NoContent();
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside UpdateSchool action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Deletes a school from the data respository by its unique id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchool(Guid id)
        {
            try
            {
                var school = await _repositoryWrapper.School.GetSchoolById(id);
                if (school.IsEmptyObject())
                {
                    _loggerManager.LogError($"School with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                if ((await _repositoryWrapper.SchoolStudent.SchoolStudentsBySchool(id)).Any())
                {
                    _loggerManager.LogError($"Cannot delete school with id: {id}. It has related schoolStudents. Delete those schoolStudents first");
                    return BadRequest("Cannot delete school. It has related schoolStudents. Delete those schoolStudents first");
                }
                await _repositoryWrapper.School.DeleteSchool(school);
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