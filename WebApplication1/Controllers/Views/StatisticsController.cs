using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using GameWebApplication.Controllers.Data;
using GameWebApplication.Models;
using GameWebApplication.ViewModels;
using Microsoft.AspNet.Identity;

namespace GameWebApplication.Controllers.Views
{
    public class StatisticsController : Controller
    {
        [Route("Statistics")]
        public ActionResult ByUser()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            string userId = authManager.User.Identity.GetUserId();
            //            ViewBag.Title = "Statistics";
            CharacterController charController = new CharacterController();
            var charactersByUser = charController.GetCharacter().Where(character => character.UserId.Equals(userId)).ToList();
            Data.StatisticsController statController = new Data.StatisticsController();
            var statistics = statController.GetStatistics().Where(stat => charactersByUser != null && charactersByUser.Select(character => character.Id).Contains(stat.CharacterId)).ToList();

            var viewModel = new StatisticsViewModel
            {
                Characters = charactersByUser,
                Statistics = statistics
            };


            return View(viewModel);
        }

    }
}
