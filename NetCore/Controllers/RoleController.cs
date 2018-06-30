using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DTO.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCore.Controllers
{
    public class RoleController : Controller
    {

        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleController(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }


        // GET: /<controller>/
        public IActionResult UserRole()
        {
            List<ApplicationRole> model = new List<ApplicationRole>();
            model = _roleManager.Roles.Select(role => new ApplicationRole
            {
                Id = role.Id,
                Name = role.Name,
                IPAddress = role.IPAddress,
                Description = role.Description,
                CreatedDate = role.CreatedDate
            }).ToList();
            ViewBag.UserRoleList = model;
            return View();
        }
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                ApplicationRole applicationRole = await _roleManager.FindByIdAsync(id);
                if (applicationRole != null)
                {
                    IdentityResult roleRuslt = _roleManager.DeleteAsync(applicationRole).Result;
                    if (roleRuslt.Succeeded)
                    {
                        return RedirectToAction("UserRole", "Role");
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> AddRole(ApplicationRole model)
        {
           
            if (ModelState.IsValid)
            {
                ApplicationRole applicationRole = new ApplicationRole();
                applicationRole.Name = model.Name;
                applicationRole.CreatedDate = DateTime.Now;
                applicationRole.Description = model.Description;
                applicationRole.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                IdentityResult roleRuslt = await _roleManager.CreateAsync(applicationRole);
                if (roleRuslt.Succeeded)
                {
                    return RedirectToAction("UserRole", "Role");
                }
            }
            return View("UserRole");
        }


        public async Task<IActionResult> UpdateRole(ApplicationRole model, String id)
        {
            bool isExist = !String.IsNullOrEmpty(id);
            if (ModelState.IsValid && isExist)
            {
                ApplicationRole applicationRole = await _roleManager.FindByIdAsync(id);
                applicationRole.Name = model.Name;
                applicationRole.Description = model.Description;
                applicationRole.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                IdentityResult roleRuslt = await _roleManager.UpdateAsync(applicationRole);
                if (roleRuslt.Succeeded)
                {
                    return RedirectToAction("UserRole", "Role");
                }
            }
            return View(model);
        }
    }
}
