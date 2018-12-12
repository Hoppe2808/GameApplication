using GameWebApplication.Models;
using GameWebApplication.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using GameWebApplication.Controllers.Data;

namespace GameWebApplication.Controllers.Views
{
    public class AdminPageController : Controller
    {
        [Authorize(Roles = "admin")]
        [Route("AdminPage/AdminPage")]
        public ActionResult AdminPage()
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            bool validateUser = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

            if (validateUser)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}