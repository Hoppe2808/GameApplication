using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;
using GameWebApplication.Controllers.Data;
using GameWebApplication.Models;

namespace GameWebApplication.Controllers.Views
{
    public class HomeController : Controller
    {
        protected string message { get; set; }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            string username = Request.Form["uname"];

            if (!username.IsEmpty() && username != null)
            {
                string password = Request.Form["psw"];

                UsersController usersController = new UsersController();
                List<User> users = usersController.GetUsers();

                foreach (User user in users)
                {
                    if (user.Username.Equals(username) && user.Password.Equals(password))
                    {
                        Response.Redirect(String.Format("statistics/{0}", user.Id));
                        ViewBag.Title = "Statistics Page";
                    }   return View();
                }
            }
            message = Request.Form["message"];
            message = "Login Failed";
            return View();
        }

        public ActionResult UsersPage()
        {
            ViewBag.Title = "Users Page";

            return View();
        }

        public ActionResult StatisticsPage()
        {
            ViewBag.Title = "Stats Page";

            return Content("There are no statistics if you are not logged in!");
        }

        public ActionResult CharacterPage()
        {
            ViewBag.Title = "Stats Page";

            return View();
        }

    }
}
