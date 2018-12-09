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
        [Route("AdminPage/AdminPage")]
        public ActionResult AdminPage()
        {
            return View();
        }
    }
}