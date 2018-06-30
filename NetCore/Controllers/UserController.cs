using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DTO.Data;
using DTO.Models;
using DTO.Models.User;
using X.PagedList;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCore.Controllers
{
    public class UserController : Controller
    {      
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public UserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;            
        }


        // GET: /<controller>/
        public IActionResult Index(int? page)
        {
            List<UserModel> model = new List<UserModel>();
            model = _userManager.Users.Select(user => new UserModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,                
               
            }).ToList();
            
            ViewBag.UserList = model;
           

         




            UserModel modelSelectList = new UserModel();
            modelSelectList.ApplicationRoles = _roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList();
            ViewBag.modelSelectList = modelSelectList;
            return View();
           
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                ApplicationUser applicationUser = await _userManager.FindByIdAsync(id);
                if (applicationUser != null)
                {
                    IdentityResult roleRuslt = _userManager.DeleteAsync(applicationUser).Result;
                    if (roleRuslt.Succeeded)
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserModel model)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.UserName = model.Email;
                applicationUser.Email = model.Email;                
                IdentityResult roleRuslt = await _userManager.CreateAsync(applicationUser, model.Password);
                if (roleRuslt.Succeeded)
                {
                    ApplicationRole applicationRole = await _roleManager.FindByIdAsync(model.ApplicationRoleId);
                    if (applicationRole != null)
                    {
                        IdentityResult roleResult = await _userManager.AddToRoleAsync(applicationUser, applicationRole.Name);
                        if (roleResult.Succeeded)
                        {
                            return RedirectToAction("Index", "User");
                        }
                    }
                }
            }
            return View(model);
        }


        public async Task<IActionResult> UpdateUser(UserModel model, String id)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByIdAsync(id);
                string existingRole = _userManager.GetRolesAsync(user).Result.Single();
                if (user != null)
                {
                    user.UserName = model.Email;
                    user.Email = model.Email;

                    

                    string existingRoleId = _roleManager.Roles.Single(r => r.Name == existingRole).Id;

                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        if (existingRoleId != model.ApplicationRoleId)
                        {
                            IdentityResult roleResult = await _userManager.RemoveFromRoleAsync(user, existingRole);
                            if (roleResult.Succeeded)
                            {
                                ApplicationRole applicationRole = await _roleManager.FindByIdAsync(model.ApplicationRoleId);
                                if (applicationRole != null)
                                {
                                    IdentityResult newRoleResult = await _userManager.AddToRoleAsync(user, applicationRole.Name);
                                    if (newRoleResult.Succeeded)
                                    {
                                        return RedirectToAction("Index", "User");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return View(model);
        }


        public async Task<IActionResult> DeleteUser(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser applicationUser = await _userManager.FindByIdAsync(id);
                if (applicationUser != null)
                {
                    IdentityResult result = await _userManager.DeleteAsync(applicationUser);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
            }
            return View();
        }



    }
}
