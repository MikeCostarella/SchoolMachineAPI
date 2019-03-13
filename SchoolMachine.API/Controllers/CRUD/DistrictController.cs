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

namespace SchoolMachine.API.Controllers.CRUD
{
    /// <summary>
    /// Handles CRUD functionality for the district entity.
    /// </summary>
    [Route("api/district")]
    [ApiController]
    public class DistrictController : ControllerBaseSchoolMachine
    {
        #region Constructors

        public DistrictController(ILoggerManager loggerManager, IMapper mapper, IRepositoryWrapper repositoryWrapper)
            : base(loggerManager, mapper, repositoryWrapper)
        {
        }

        #endregion Constructors

        #region Actions

        /// <summary>
        /// Gets all districts from the data store
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllDistricts()
        {
            try
            {
                var districts = await _repositoryWrapper.District.GetAllDistricts();
                _loggerManager.LogInfo($"Returned all districts from database.");
                return Ok(districts);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside GetAllDistricts action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Gets a district from the data respository by its unique id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetDistrictById")]
        public async Task<IActionResult> GetDistrictById(Guid id)
        {
            try
            {
                var district = await _repositoryWrapper.District.GetDistrictById(id);
                if (district.IsEmptyObject())
                {
                    _loggerManager.LogError($"District with id: {id}, was not found in db.");
                    return NotFound();
                }
                else
                {
                    _loggerManager.LogInfo($"Returned district with id: {id}");
                    return Ok(district);
                }
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside GetDistrictById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Gets Schools from the data repository by a unique District id
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        [HttpGet("GetSchoolsByDistrictId", Name = "GetSchoolsByDistrictId")]
        public async Task<IActionResult> GetSchoolsByDistrictId(Guid districtId)
        {
            try
            {
                var schools = await _repositoryWrapper.District.GetSchoolsByDistrictId(districtId);
                _loggerManager.LogInfo($"Returned { schools.Count() } Schools from repository for District { districtId }.");
                return Ok(schools);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside GetSchoolsByStudentId action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Creates a new district in the data respository based on a unique name
        /// </summary>
        /// <param name="districtDto"></param>
        /// <returns></returns>
        [HttpPost("CreateDistrict", Name = "CreateDistrict")]
        public async Task<IActionResult> CreateDistrict([FromBody] DistrictDto districtDto)
        {
            try
            {
                if (districtDto == null)
                {
                    _loggerManager.LogError("DistrictDto sent from client is null.");
                    return BadRequest("DistrictDto is null");
                }
                if (!ModelState.IsValid)
                {
                    _loggerManager.LogError("Invalid DistrictDto object sent from client.");
                    return BadRequest("Invalid DistrictDto model object");
                }
                var district = _mapper.Map<District>(districtDto);
                await _repositoryWrapper.District.CreateDistrict(district);
                if (district.IsEmptyObject())
                {
                    _loggerManager.LogError($"Save operation failed inside CreateDistrict action");
                    return StatusCode(500, "Internal server error while saving School ");
                }
                var dbDistrict = await _repositoryWrapper.District.GetDistrictById(district.Id);
                return Ok(dbDistrict);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside CreateSchool action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Updates a district in the respository, identified by it unique id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="districtDto"></param>
        /// <returns></returns>
        [HttpPut("UpdateDistrict/id")]
        public async Task<IActionResult> UpdateDistrict([FromQuery] Guid id, [FromBody] DistrictDto districtDto)
        {
            try
            {
                if (districtDto == null)
                {
                    _loggerManager.LogError("DistrictDto sent from client is null.");
                    return BadRequest("DistrictDto object is null");
                }
                if (!ModelState.IsValid)
                {
                    _loggerManager.LogError("Invalid DistrictDto sent from client.");
                    return BadRequest("Invalid DistrictDto model object");
                }
                var dbDistrict = await _repositoryWrapper.District.GetDistrictById(id);
                if (dbDistrict.IsEmptyObject())
                {
                    _loggerManager.LogError($"District with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                var district = _mapper.Map<District>(districtDto);
                await _repositoryWrapper.District.UpdateDistrict(dbDistrict, district);
                return NoContent();
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside UpdateDistrict action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Deletes a district from the data respository by its unique id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistrict(Guid id)
        {
            try
            {
                var district = await _repositoryWrapper.District.GetDistrictById(id);
                if (district.IsEmptyObject())
                {
                    _loggerManager.LogError($"School with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                if ((await _repositoryWrapper.DistrictSchool.DistrictSchoolsByDistrict(id)).Any())
                {
                    _loggerManager.LogError($"Cannot delete district with id: {id}. It has related DistrictSchools. Delete those DistrictSchools first");
                    return BadRequest("Cannot delete district. It has related DistrictSchools. Delete those DistrictSchools first");
                }
                await _repositoryWrapper.District.DeleteDistrict(district);
                return NoContent();
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong inside DeleteDistrict action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion Actions
    }
}
