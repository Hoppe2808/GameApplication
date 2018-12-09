using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using GameWebApplication.Controllers.Data;
using GameWebApplication.Models;
using GameWebApplication.Models.ViewModels;
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

        [Authorize(Roles = "admin")]
        [Route("Statistics/AllStatsPage")]
        public ActionResult AllStatsPage()
        {
            UsersController uc = new UsersController();
            CharacterController cc = new CharacterController();
            Data.StatisticsController sc = new Data.StatisticsController();

            AllStatsViewModel viewModel = new AllStatsViewModel
            {
                Usernames = new List<string>(),
                Statistics = new List<Statistics>()
            };

            List<User> users = uc.GetUsers();
            List<Character> chars = cc.GetCharacter();

            foreach (User user in users)
            {
                var charactersByUser = cc.GetCharacter().Where(character => character.UserId.Equals(user.Id)).ToList();
                List<Statistics> statsForUser = sc.GetStatistics().Where(stat => charactersByUser.Select(character => character.Id).Contains(stat.CharacterId)).ToList();
                Statistics collectedStats = new Statistics();

                if (statsForUser.Count() == 0)
                {
                    collectedStats.Deaths += 0;
                    collectedStats.Kills += 0;
                    collectedStats.TotalMoney += 0;
                }
                else
                {
                    foreach (Statistics stat in statsForUser)
                    {
                        collectedStats.Deaths += stat.Deaths;
                        collectedStats.Kills += stat.Kills;
                        collectedStats.TotalMoney += stat.TotalMoney;
                    }
                }
                viewModel.Usernames.Add(user.UserName);
                viewModel.Statistics.Add(collectedStats);
            }

            return View(viewModel);
        }

    }
}
