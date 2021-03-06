﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba.Models;
using ZooLine.Controllers;

namespace Identity.Controllers
{
    [Authorize(Roles="guia")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<Usuario> userManager;
        public RoleController(RoleManager<IdentityRole> roleMgr, UserManager<Usuario> userMgr)
        {
            roleManager = roleMgr;
            userManager = userMgr;

        }

        public ViewResult Index() => View(roleManager.Roles);
        public IActionResult Create() => View();

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
        [HttpPost]
        public async Task<IActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            return View(name);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("Index", roleManager.Roles);
        }
        public async Task<IActionResult> Update(string id)
        {
          
           
             var role = await roleManager.FindByIdAsync(id);

                List<Usuario> members = new List<Usuario>();
                List<Usuario> nonMembers = new List<Usuario>();
              var users = await  userManager.Users.ToListAsync();
                 
                    foreach (Usuario user in users)
                    {
                        var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                        list.Add(user);
                    }
                    return View(new RoleEdit

                    {
                        Role = role,
                        Members = members,
                        NonMembers = nonMembers
                    });
                       
           
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoleModification model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                using (userManager)
                {
                    foreach (string userId in model.AddIds ?? new string[] { })
                    {
                        Usuario user = await userManager.FindByIdAsync(userId);
                        if (user != null)
                        {
                            result = await userManager.AddToRoleAsync(user, model.RoleName);
                            if (!result.Succeeded)
                                Errors(result);
                        }
                    }
                    // aqui es donde succede el error ala paracer usemanger y role manger usan el mismo dbcontext 
                    using (roleManager)
                    {
                        foreach (string userId in model.DeleteIds ?? new string[] { })
                        {
                            Usuario user = await userManager.FindByIdAsync(userId);
                            if (user != null)
                            {
                                result = await userManager.RemoveFromRoleAsync(user, model.RoleName);
                                if (!result.Succeeded)
                                    Errors(result);
                            }
                        }
                    }
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            else
                return await Update(model.RoleId);
        }
    }
}

