using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;
using GameWebApplication.Controllers.Data;
using GameWebApplication.Models;
using GameWebApplication.ViewModels;

namespace GameWebApplication.Controllers.Views
{
    public class StatisticsController : Controller
    {
        [Route("statistics/{userId}")]
        public ActionResult ByUser(int userId)
        {
            //            ViewBag.Title = "Statistics";
            CharacterController charController = new CharacterController();
            var charactersByUser = charController.GetCharacter().Where(character => character.UserId == userId).ToList();
            Data.StatisticsController statController = new Data.StatisticsController();
            var statistics = statController.GetStatistics().Where(stat => charactersByUser != null && charactersByUser.Select(character => character.Id).Contains(stat.Id)).ToList();

            var viewModel = new StatisticsViewModel
            {
                Characters = charactersByUser,
                Statistics = statistics
            };


            return View(viewModel);
        }

    }
}
