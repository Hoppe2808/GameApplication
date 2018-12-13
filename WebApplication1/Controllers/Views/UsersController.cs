using GameWebApplication.Models;
using GameWebApplication.Models.ViewModels;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace GameWebApplication.Controllers.Views
{
    public class UsersController : Controller
    {
        private AppUserManager userManager;

        // GET: Users
        [Route("Users/User")]
        public ActionResult User()
        {
            bool validateUser = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

            if (validateUser)
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [Route("Users/EditUsers")]
        public ActionResult EditUser(EditUserViewModel input)
        {
            if (input.UserName != null)
            {
                return View(input);
            }

            EditUserViewModel user = new EditUserViewModel();
            var authManager = HttpContext.GetOwinContext().Authentication;
            user.UserName = authManager.User.Identity.GetUserName();

            return View(user);
        }


        public ActionResult ChangeUsername(EditUserViewModel input)
        {
            userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            User user = userManager.FindById(authManager.User.Identity.GetUserId());

            user.UserName = input.UserName;

            userManager.Update(user);

            return RedirectToAction("EditUser", input);
        }

        public ActionResult ChangePassword(EditUserViewModel input)
        {
            if (input.OldPassword == null || input.Password == null)
            {
                ModelState.AddModelError("empty_password", "You have to fill in a value for both old and new password.");
            }
            else
            {
                userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                var authManager = HttpContext.GetOwinContext().Authentication;

                string userId = authManager.User.Identity.GetUserId();

                userManager.ChangePassword(userId, input.OldPassword, input.Password);
            }

            return RedirectToAction("EditUser", input);
        }
    }
}