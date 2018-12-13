using GameWebApplication.Models;
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
            bool validateUser = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

            if (validateUser)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [Route("UsersPage/EditUsersPage")]
        public ActionResult EditUserPage(EditUserViewModel input)
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
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            User user = userManager.FindById(authManager.User.Identity.GetUserId());

            user.UserName = input.UserName;

            userManager.Update(user);

            return RedirectToAction("EditUserPage", input);
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