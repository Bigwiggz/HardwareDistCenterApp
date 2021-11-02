using HardwareStoreAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareStoreAPI.Controllers
{
    public class PersonnelController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public PersonnelController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            UserRolesViewModel userRoles = new UserRolesViewModel();

            List<UserAndTheirRole> userRolesList = new List<UserAndTheirRole>();

            var users = _userManager.Users.ToList();
            var roles = _roleManager.Roles.ToList();

            userRoles.AllRolesList = roles;

            foreach (var user in users)
            {
                UserAndTheirRole userRoleCombo = new UserAndTheirRole();

                userRoleCombo.User = user;

                var userRole = await _userManager.GetRolesAsync(user);

                var userRoleName = new List<string>(userRole).FirstOrDefault();

                userRoleCombo.UserRoleName = userRoleName;

                userRolesList.Add(userRoleCombo);
            }

            userRoles.UsersRolesList = userRolesList;
            
            return View(userRoles);
        }
    }
}
