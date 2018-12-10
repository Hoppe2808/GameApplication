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

        [Route("Register")]
        public ActionResult RegisterUserPage()
        {
            ViewBag.Title = "Register Page";

            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> RegisterUser(RegisterUserViewModel userData)
        {
            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();

                User existingUser = userManager.FindByName(userData.Username);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "User alredy exists");
//                    return Redirect(Url.Action("RegisterUserPage"));
                    return RedirectToAction("RegisterUserPage");
                }
                else if (!userData.Password.Equals(userData.ConfirmPassword))
                {
                    ModelState.AddModelError("", "The two passwords entered doesn't match");
                    return Redirect(Url.Action("RegisterUserPage"));
                }
                User user = new User { UserName = userData.Username };
                IdentityResult result = await userManager.CreateAsync(user, userData.Password);

                if (result.Succeeded)
                {
                    string test = "test";
                }
                else
                {
                    String test = "test2";
                }
            }
            return Redirect(Url.Action("Index", "Home"));
        }
    }
}