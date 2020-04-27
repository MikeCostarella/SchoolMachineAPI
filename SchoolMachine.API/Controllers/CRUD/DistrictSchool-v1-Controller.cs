using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.API.Controllers.Base;
using SchoolMachine.API.Models;
using SchoolMachine.Contracts;
using SchoolMachine.DataAccess.Entities.Extensions.Base;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMachine.API.Controllers.CRUD
{
    /// <summary>
    /// Provides CRUD functionality for DistrictSchool(s)
    /// </summary>
    [Authorize("Authorized", AuthenticationSchemes = "custom")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiversion}/[controller]")]
    [Produces("application/json")]
    public class DistrictSchoolController : ControllerBaseSchoolMachine
    {
        #region Constructors

        public DistrictSchoolController(ILoggerManager loggerManager, IMapper mapper, IRepositoryWrapper repositoryWrapper)
            : base(loggerManager, mapper, repositoryWrapper)
        {
        }

        #endregion Constructors

        #region Actions

        /// <summary>
        /// Gets all DistrictSchool(s) from the data repository
        /// </summary>
        /// <returns>IEnumerable of DistrictSchool(s) </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllDistrictSchools()
        {
            try
            {
                var districtSchools = await _repositoryWrapper.DistrictSchool.GetAllDistrictSchools();
                _loggerManager.LogInfo($"Returned all DistrictSchools from database.");
                return Ok(districtSchools);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside GetAllDistrictSchools action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Gets a DistrictSchool from the data repository by its unique id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetDistrictSchoolById{id}", Name = "GetDistrictSchoolById")]
        public async Task<IActionResult> GetDistrictSchoolById(Guid id)
        {
            try
            {
                var districtSchool = await _repositoryWrapper.DistrictSchool.GetDistrictSchoolById(id);
                if (districtSchool.Id.Equals(Guid.Empty))
                {
                    _loggerManager.LogError($"DistrictSchool with id: {id}, was not found in db.");
                    return NotFound();
                }
                else
                {
                    _loggerManager.LogInfo($"Returned DistrictSchool with id: {id}");
                    return Ok(districtSchool);
                }
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside GetDistrictSchoolById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Gets DistrictSchool(s) from the repository by a unique School id
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        [HttpGet("GetDistrictSchoolsBySchoolId", Name = "GetDistrictSchoolsBySchoolId")]
        public async Task<IActionResult> GetDistrictSchoolsBySchoolId(Guid schoolId)
        {
            try
            {
                var districtSchools = await _repositoryWrapper.DistrictSchool.DistrictSchoolsBySchool(schoolId);
                _loggerManager.LogInfo($"Returned { districtSchools.Count() } DistrictSchools from repository for School { schoolId }.");
                return Ok(districtSchools);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside GetDistrictSchoolsBySchoolId action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Gets DistrictSchool(s) from the repository by a unique District id
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        [HttpGet("GetDistrictSchoolsByDistrictId", Name = "GetDistrictSchoolsByDistrictId")]
        public async Task<IActionResult> GetDistrictSchoolsByDistrictId(Guid districtId)
        {
            try
            {
                var districtSchools = await _repositoryWrapper.DistrictSchool.DistrictSchoolsByDistrict(districtId);
                _loggerManager.LogInfo($"Returned { districtSchools.Count() } DistrictSchools from repository for District { districtId }.");
                return Ok(districtSchools);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside GetDistrictSchoolsByStudentId action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Creates a new DistrictSchool in the repository
        /// </summary>
        /// <param name="districtSchoolDto"></param>
        [HttpPost("CreateDistrictSchool", Name = "CreateDistrictSchool")]
        public async Task<IActionResult> CreateDistrictSchool([FromBody] DistrictSchoolDto districtSchoolDto)
        {
            try
            {
                if (districtSchoolDto == null)
                {
                    _loggerManager.LogError("DistrictSchoolDto sent from client is null.");
                    return BadRequest("DistrictSchoolDto object is null");
                }
                if (!ModelState.IsValid)
                {
                    _loggerManager.LogError("Invalid DistrictSchoolDto sent from client.");
                    return BadRequest("Invalid DistrictSchoolDto model object");
                }
                var districtSchool = _mapper.Map<DistrictSchool>(districtSchoolDto);
                await _repositoryWrapper.DistrictSchool.CreateDistrictSchool(districtSchool);
                if (districtSchool.IsEmptyObject())
                {
                    _loggerManager.LogError($"Save operation failed inside CreateDistrictSchool action");
                    return StatusCode(500, "Internal server error while saving School ");
                }
                var dbObject = await _repositoryWrapper.DistrictSchool.GetDistrictSchoolById(districtSchool.Id);
                return Ok(dbObject);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside CreateDistrictSchool action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Updates a DistrictSchool, identified by its unique id, in the repository.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="districtSchoolDto"></param>
        [HttpPut("UpdateDistrictSchool")]
        public async Task<IActionResult> UpdateDistrictSchool([FromQuery] Guid id, [FromBody] DistrictSchoolDto districtSchoolDto)
        {
            try
            {
                if (districtSchoolDto == null)
                {
                    _loggerManager.LogError("DistrictSchoolDto object sent from client is null.");
                    return BadRequest("DistrictSchoolDto object is null");
                }
                if (!ModelState.IsValid)
                {
                    _loggerManager.LogError("Invalid DistrictSchoolDto object sent from client.");
                    return BadRequest("Invalid DistrictSchoolDto model object");
                }
                var dbDistrictSchoolDto = await _repositoryWrapper.DistrictSchool.GetDistrictSchoolById(id);
                if (dbDistrictSchoolDto.IsEmptyObject())
                {
                    _loggerManager.LogError($"School with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                var districtSchool = _mapper.Map<DistrictSchool>(districtSchoolDto);
                await _repositoryWrapper.DistrictSchool.UpdateDistrictSchool(dbDistrictSchoolDto, districtSchool);
                return NoContent();
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside UpdateDistrictSchool action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Deletes a DistrictSchool object form the data repository
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistrictSchool(Guid id)
        {
            try
            {
                var districtSchool = await _repositoryWrapper.DistrictSchool.GetDistrictSchoolById(id);
                if (districtSchool.IsEmptyObject())
                {
                    _loggerManager.LogError($"DistrictSchool with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                await _repositoryWrapper.DistrictSchool.DeleteDistrictSchool(districtSchool);
                return NoContent();
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside DeleteDistrictSchool action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion Actions
    }
}
