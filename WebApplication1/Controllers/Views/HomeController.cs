using GameWebApplication.Models;
using GameWebApplication.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using GameWebApplication.Controllers.Data;

namespace GameWebApplication.Controllers.Views
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Home")]
        public ActionResult Login(UserViewModel input)
        {
            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                var authManager = HttpContext.GetOwinContext().Authentication;

                User user = userManager.Find(input.UserName, input.Password);
                if (user != null)
                {
                    var ident = userManager.CreateIdentity(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    //use the instance that has been created. 
                    authManager.SignIn(
                        new AuthenticationProperties { IsPersistent = false }, ident);
                    return RedirectToAction("ByUser", "Statistics");
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return Redirect(Url.Action("Index"));
        }

        public ActionResult UsersPage()
        {
            ViewBag.Title = "Users Page";

            return View();
        }

        public ActionResult CharacterPage()
        {
            CharacterController characterController = new CharacterController();
            List<Character> characters = characterController.GetCharacter().ToList();

            ViewBag.Title = "Character Page";

            return View(characters);
        }

        public ActionResult AdminPage()
        {
            UsersController usersController = new UsersController();
            List<User> users = usersController.GetUsers();



            ViewBag.Title = "Admin Page";

            return View(users);
        }

        public ActionResult CreateUser()
        {
            ViewBag.Title = "CREATING USER";

            return View();
        }

        public ActionResult StatisticsPage()
        {
            ViewBag.Title = "Stats Page";

            return Content("There are no statistics if you are not logged in!");
        }
    }
}
