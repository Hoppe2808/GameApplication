using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameWebApplication.Controllers.Views
{
    public class UsersPageController : Controller
    {
        // GET: UsersPage
        public ActionResult Index()
        {
            return View();
        }
    }
}