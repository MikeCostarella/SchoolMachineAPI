using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using SchoolMachine.DataAccess.Entities.Authorization.Models.Identity;
using SchoolMachine.Contracts;
using SchoolMachine.API.Services;
using SchoolMachine.API.Dtos;

namespace SchoolMachine.API.Controllers.Security
{
    /// <summary>
    /// Authetication functionality
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiversion}/authentication/[action]")]
    [Produces("application/json")]
    public class AuthenticationApiController : ControllerBase
    {
        #region Member Variables

        private readonly IAuthTokenGeneratorService authTokenGeneratorService;
        private readonly ILoggerManager loggerManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        #endregion Member Variables

        #region Constructors

        public AuthenticationApiController(
            IAuthTokenGeneratorService authTokenGeneratorService,
            ILoggerManager loggerManager,
            RoleManager<IdentityRole<Guid>> roleManager,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            this.authTokenGeneratorService = authTokenGeneratorService ?? throw new ArgumentNullException(nameof(authTokenGeneratorService));
            this.loggerManager = loggerManager ?? throw new ArgumentNullException(nameof(loggerManager));
            this.roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            this.signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        #endregion Constructors

        #region Actions

        /// <summary>
        /// Authenticate a user and password for subsequent entry points
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(UserAuthenticationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Authenticate(UserAuthenticationRequest request)
        {
            try
            {
                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request));
                }
                var user = await this.userManager.FindByNameAsync(request.Username);
                if (user == null)
                {
                    return this.Unauthorized(new { message = "Authentication failed" });
                }
                var result = await this.signInManager.PasswordSignInAsync(user, request.Password, false, false);
                if (!result.Succeeded)
                {
                    return this.Unauthorized(new { message = "Authentication failed" });
                }
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
                };
                var userClaims = new List<Claim>();
                var userRoles = await this.userManager.GetRolesAsync(user);
                foreach (var role in userRoles)
                {
                    var identityRole = await this.roleManager.FindByNameAsync(role);
                    userClaims.Add(new Claim("role", identityRole.Name));
                    userClaims.AddRange(await this.roleManager.GetClaimsAsync(identityRole));
                }
                userClaims.AddRange(await this.userManager.GetClaimsAsync(user));
                claims.AddRange(userClaims);
                var token = this.authTokenGeneratorService.GenerateToken(claims);
                var response = new UserAuthenticationResponse
                {
                    IsSuccessful = true,
                    Message = $"Authenticate: Successfully authenticated user: [{ user.Id }].",
                    Permissions = userClaims.Where(x => x.Type != "role").Select(x => x.Value).ToList(),
                    Roles = userRoles.ToList(),
                    Token = token,
                    UserId = user.Id,
                    Username = user.UserName
                };
                return this.Ok(response);
            }
            catch (Exception ex)
            {
                this.loggerManager.LogError(ex.ToString());
                return StatusCode(500, "Authentication failed");
            }
        }

        #endregion Actions
    }
}