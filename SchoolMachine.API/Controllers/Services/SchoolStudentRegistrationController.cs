using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMachine.ServiceModel.DomainRequests;
using SchoolMachine.ServiceModel.DomainResponses;

namespace SchoolMachine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolStudentRegistrationController : ControllerBase
    {

        // POST: api/Student
        [HttpPost]
        public StudentSchoolRegistrationResponse Post([FromBody] StudentSchoolRegistrationRequest value)
        {
            // TODO: fill in logic
            return new StudentSchoolRegistrationResponse();
        }
    }
}