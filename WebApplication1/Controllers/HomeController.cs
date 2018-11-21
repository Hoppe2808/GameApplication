using GameWebApplication.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.WebPages;

namespace GameWebApplication.Controllers
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
                        Response.Redirect("Home/UsersPage");
                        ViewBag.Title = "Users Page";
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
    }
}
