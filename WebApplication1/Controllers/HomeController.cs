using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            

            return View();
        }

        public ActionResult UsersPage()
        {
            ViewBag.Title = "Users Page";

            return View();
        }
    }
}
