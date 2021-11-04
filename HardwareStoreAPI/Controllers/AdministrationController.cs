using HardwareStoreAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareStoreAPI.Controllers
{
    
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager,UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                //We just need to specify a unique role name to crete a new role
                IdentityRole identityRole = new IdentityRole 
                {
                    Name=model.RoleName
                };

                var roleExist = await _roleManager.RoleExistsAsync(identityRole.Name);

                if (!roleExist)
                {
                    IdentityResult result = await _roleManager.CreateAsync(identityRole);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("index", "home");
                    }

                    //Saves the role in the underlying AspNetRoles table


                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            //Find the Role given the Id
            var role = await _roleManager.FindByIdAsync(id);

            if (role is null)
            {
                ViewBag.ErrorMessage = $"Role with Id={id} cannot be found";
                return View("NotFound");
            }

            var model = new EditRoleViewModel 
            { 
                Id=role.Id,
                RoleName=role.Name
            };
            
            //Retrieve all users in said role
            foreach (var user in _userManager.Users.ToList())
            {
                var isInRole = false;
                isInRole = await _userManager.IsInRoleAsync(user, role.Name);
                if (isInRole)
                {
                    model.Users.Add(user.UserName);
                }
                
            }
            
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role= await _roleManager.FindByIdAsync(model.Id);

            if (role is null)
            {
                ViewBag.ErrorMessage = $"Role with Id: {model.Id} cannot be found.";
            }
            else 
            {
                role.Name = model.RoleName;

                //Update the Role using UpdateAsync
                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role is null)
            {
                ViewBag.ErrorMessage = $"Role with Id: {id} cannot be found.";
            }

            var result = await _roleManager.DeleteAsync(role);

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(role.Name);
        }
    }
}
