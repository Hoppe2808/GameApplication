using GameWebApplication.Models;
using GameWebApplication.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameWebApplication.Controllers.Views
{
    public class RegisterController : Controller
    {
        private AppUserManager userManager;

        [Route("Register")]
        public ActionResult RegisterUser(RegisterUserViewModel model)
        {
            ViewBag.Title = "Register Page";

            return View(model);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> DoRegisterUser(RegisterUserViewModel userData)
        {
            if (ModelState.IsValid)
            {
                userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();

                if (string.IsNullOrEmpty(userData.Username) || string.IsNullOrEmpty(userData.Password) || string.IsNullOrEmpty(userData.ConfirmPassword))
                {
                    ModelState.AddModelError("empty_fields", "Please fill out all fields");
                    return View("RegisterUserPage", userData);
                }

                User existingUser = userManager.FindByName(userData.Username);
                if (existingUser != null)
                {
                    ModelState.AddModelError("user_exists", "User alredy exists");
                    return View("RegisterUser", userData);
                }
                if (!userData.Password.Equals(userData.ConfirmPassword))
                {
                    ModelState.AddModelError("pwds_dont_match", "The two passwords entered do not match");
                    return View("RegisterUser", userData);
                }
                User user = new User { UserName = userData.Username };
                IdentityResult result = await userManager.CreateAsync(user, userData.Password);


                if (result.Succeeded)
                {
                    if (userData.Admin)
                    {
                        userManager.AddToRole(userManager.FindByName(user.UserName).Id, "admin");
                    }
                    else
                    {
                        userManager.AddToRole(userManager.FindByName(user.UserName).Id, "default");
                    }
                    ModelState.AddModelError("identity_success", "User successfully created.");
                    return View("RegisterUser", userData);
                }
                ModelState.AddModelError("identity_error", result.Errors.First());
                return View("RegisterUser", userData);
            }
            return Redirect(Url.Action("Index", "Home"));
        }
    }
}