using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
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
                Users = new List<User>(),
                Statistics = new List<Statistics>(),
                Characters = new List<Character>()
            };

            List<User> users = uc.GetUsers();
            List<Character> chars = cc.GetCharacter();

            foreach (User user in users)
            {
                var charactersByUser = cc.GetCharacter().Where(character => character.UserId.Equals(user.Id)).ToList();
                List<Statistics> statsForCharacter = sc.GetStatistics().Where(stat => charactersByUser.Select(character => character.Id).Contains(stat.CharacterId)).ToList();

                viewModel.Users.Add(user);
                viewModel.Statistics.AddRange(statsForCharacter);
                viewModel.Characters.AddRange(charactersByUser);
            }

            return View(viewModel);
        }

        public ActionResult EditCharacter(int id)
        {
            CharacterController characterController = new CharacterController();
            Data.StatisticsController statisticsController = new Data.StatisticsController();
            var characterToEdit = (characterController.GetCharacter(id) as OkNegotiatedContentResult<Character>);
            if (characterToEdit == null)
            {

//                return RedirectToAction();
            }
            var statsForCharacter = statisticsController.GetStatistics().Find(stat => stat.CharacterId == id);

            var model = new EditCharacterViewModel
            {
                Character = characterToEdit,
                Statistics = statsForCharacter,
                CharacterName = characterToEdit.Name,
                Kills = statsForCharacter.Kills
            };

            return View(model);
        }

        public ActionResult ChangeCharacterName(Character input)
        {

            return RedirectToAction("EditCharacter");
        }

    }
}
