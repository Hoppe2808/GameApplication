﻿using GameWebApplication.Models;
using GameWebApplication.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameWebApplication.Controllers.Data;

namespace GameWebApplication.Controllers.Views
{
    public class HomeController : Controller
    {
        public ActionResult Index(UserViewModel model)
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return View(model);
        }

        [HttpPost]
        [Route("Home")]
        public ActionResult Login(UserViewModel input)
        {
            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                var authManager = HttpContext.GetOwinContext().Authentication;
                if (input.UserName != null && input.Password != null)
                {
                    User user = userManager.Find(input.UserName, input.Password);
                    if (user != null)
                    {
                        var ident = userManager.CreateIdentity(user,
                            DefaultAuthenticationTypes.ApplicationCookie);
                        //use the instance that has been created. 
                        authManager.SignIn(
                            new AuthenticationProperties { IsPersistent = false }, ident);
                        return RedirectToAction("UsersPage", "UsersPage");
                    }
                }
                else
                {
                    ModelState.AddModelError("fill_both", "Please fill in both user name and password");
                }
            }

            ModelState.AddModelError("wrong_info", "Invalid username or password");
            return View("Index", input);
        }

        public ActionResult CharacterPage()
        {
            CharacterController characterController = new CharacterController();
            List<Character> characters = characterController.GetCharacter().ToList();

            ViewBag.Title = "Character Page";

            return View(characters);
        }

        public ActionResult CreateUser()
        {
            ViewBag.Title = "Creating User...";

            return View();
        }

        public ActionResult StatisticsPage()
        {
            ViewBag.Title = "Stats Page";

            return Content("There are no statistics if you are not logged in!");
        }
    }
}
