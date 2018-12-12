﻿using GameWebApplication.Models;
using GameWebApplication.Models.ViewModels;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace GameWebApplication.Controllers.Views
{
    public class UsersPageController : Controller
    {
        // GET: UsersPage
        [Route("UsersPage/UsersPage")]
        public ActionResult UsersPage()
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            string userId = authManager.User.Identity.GetUserId();

            bool validateUser = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

            if (validateUser)
            {
                bool isAdmin = userManager.IsInRole(userId, "admin");
                if (isAdmin)
                {
                    return RedirectToAction("AdminPage", "AdminPage");
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize(Roles = "default")]
        [Route("UsersPage/EditUsersPage")]
        public ActionResult EditUserPage()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;

            EditUserViewModel user = new EditUserViewModel();
            user.UserName = authManager.User.Identity.GetUserName();

            return View(user);
        }

        public ActionResult ChangeUsername(EditUserViewModel input)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            User user = userManager.FindById(authManager.User.Identity.GetUserId());

            user.UserName = input.UserName;

            userManager.Update(user);

            return Redirect(Url.Action("EditUserPage", "UsersPage"));
        }

        public ActionResult ChangePassword(EditUserViewModel input)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            string userId = authManager.User.Identity.GetUserId();

            userManager.ChangePassword(userId, input.OldPassword, input.Password);
            return Redirect(Url.Action("EditUserPage", "UsersPage"));
        }
    }
}