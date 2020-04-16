using Microsoft.AspNetCore.Identity;
using SchoolMachine.Common.Extensions;
using SchoolMachine.DataAccess.Entities.Authorization;
using SchoolMachine.DataAccess.Entities.Authorization.Models.Identity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SchoolMachine.DataAccess.Entities.SeedData.Model.Identity
{
    public class IdentitySeeder
    {
        #region Member Variables

        private readonly SchoolMachineContext context;

        private readonly RoleManager<IdentityRole<Guid>> roleManager;

        private readonly UserManager<ApplicationUser> userManager;

        #endregion Member Variables

        #region Constructors

        public IdentitySeeder(
            SchoolMachineContext context,
            RoleManager<IdentityRole<Guid>> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        #endregion Constructors

        #region Actions

        public async Task Seed()
        {
            var adminRole = new IdentityRole<Guid> { Name = "Admin" };
            await roleManager.CreateAsync(adminRole);

            var publicUserRole = new IdentityRole<Guid> { Name = "PublicUser" };
            await roleManager.CreateAsync(publicUserRole);

            // claims
            var canAddDistrictsClaim = new Claim(CustomClaimTypes.Admin.GetDescription(), CustomClaimValues.CanAddDistricts.GetDescription());
            var canDeleteDistrictsClaim = new Claim(CustomClaimTypes.Admin.GetDescription(), CustomClaimValues.CanDeleteDistricts.GetDescription());
            var canModifyDistrictsClaim = new Claim(CustomClaimTypes.Admin.GetDescription(), CustomClaimValues.CanModifyDistricts.GetDescription());
            var canViewDistrictsClaim = new Claim(CustomClaimTypes.Admin.GetDescription(), CustomClaimValues.CanViewDistricts.GetDescription());
            var canAddSchoolsClaim = new Claim(CustomClaimTypes.Admin.GetDescription(), CustomClaimValues.CanAddSchools.GetDescription());
            var canDeleteSchoolsClaim = new Claim(CustomClaimTypes.Admin.GetDescription(), CustomClaimValues.CanDeleteSchools.GetDescription());
            var canModifySchoolsClaim = new Claim(CustomClaimTypes.Admin.GetDescription(), CustomClaimValues.CanModifySchools.GetDescription());
            var canViewSchoolsClaim = new Claim(CustomClaimTypes.Admin.GetDescription(), CustomClaimValues.CanViewSchools.GetDescription());
            var canAddStudentsClaim = new Claim(CustomClaimTypes.Admin.GetDescription(), CustomClaimValues.CanAddStudents.GetDescription());
            var canDeleteStudentsClaim = new Claim(CustomClaimTypes.Admin.GetDescription(), CustomClaimValues.CanDeleteStudents.GetDescription());
            var canModifyStudentsClaim = new Claim(CustomClaimTypes.Admin.GetDescription(), CustomClaimValues.CanModifyStudents.GetDescription());
            var canViewStudentsClaim = new Claim(CustomClaimTypes.Admin.GetDescription(), CustomClaimValues.CanViewStudents.GetDescription());

            // assign all claims to admin role
            await roleManager.AddClaimAsync(adminRole, canAddDistrictsClaim);
            await roleManager.AddClaimAsync(adminRole, canDeleteDistrictsClaim);
            await roleManager.AddClaimAsync(adminRole, canModifyDistrictsClaim);
            await roleManager.AddClaimAsync(adminRole, canViewDistrictsClaim);
            await roleManager.AddClaimAsync(adminRole, canAddSchoolsClaim);
            await roleManager.AddClaimAsync(adminRole, canDeleteSchoolsClaim);
            await roleManager.AddClaimAsync(adminRole, canModifySchoolsClaim);
            await roleManager.AddClaimAsync(adminRole, canViewSchoolsClaim);
            await roleManager.AddClaimAsync(adminRole, canAddStudentsClaim);
            await roleManager.AddClaimAsync(adminRole, canDeleteStudentsClaim);
            await roleManager.AddClaimAsync(adminRole, canModifyStudentsClaim);
            await roleManager.AddClaimAsync(adminRole, canViewStudentsClaim);

            // assign claims to public user role
            await roleManager.AddClaimAsync(publicUserRole, canViewDistrictsClaim);
            await roleManager.AddClaimAsync(publicUserRole, canViewSchoolsClaim);
            await roleManager.AddClaimAsync(publicUserRole, canViewStudentsClaim);

            // add user(s)
            var adminUser = new ApplicationUser
            {
                Email = "mcosti@sprynet.com",  // ToDo: change this for your purposes
                EmailConfirmed = true,
                Id = Guid.NewGuid(),
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "AdminUser"
            };
            await userManager.CreateAsync(adminUser, "password");
            await userManager.AddToRoleAsync(adminUser, adminRole.Name);

            var publicUser1 = new ApplicationUser
            {
                Email = "mcosti@sprynet.com",  // ToDo: change this for your purposes
                EmailConfirmed = true,
                Id = Guid.NewGuid(),
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "PublicUser1"
            };
            await userManager.CreateAsync(publicUser1, "password");
            await userManager.AddToRoleAsync(publicUser1, publicUserRole.Name);
        }

        #endregion Actions
    }
}
