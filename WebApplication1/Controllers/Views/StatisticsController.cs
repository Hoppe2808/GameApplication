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
        private CharacterController charController = new CharacterController();
        private Data.StatisticsController statController = new Data.StatisticsController();
        private UsersController uc = new UsersController();

        [Route("Statistics")]
        public ActionResult ByUser()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            string userId = authManager.User.Identity.GetUserId();
            
            var charactersByUser = charController.GetCharacter().Where(character => character.UserId.Equals(userId)).ToList();
            
            var statistics = statController.GetStatistics().Where(stat => charactersByUser.Count > 0 && charactersByUser.Select(character => character.Id).Contains(stat.CharacterId)).ToList();

            var viewModel = new StatisticsViewModel
            {
                UserName = authManager.User.Identity.Name,
                Characters = charactersByUser,
                Statistics = statistics
            };

            return View(viewModel);
        }

        [Authorize(Roles = "admin")]
        [Route("Statistics/AllStats")]
        public ActionResult AllStats()
        {
            AllStatsViewModel viewModel = new AllStatsViewModel
            {
                Users = new List<User>(),
                Statistics = new List<Statistics>(),
                Characters = new List<Character>()
            };

            List<User> users = uc.GetUsers();
            List<Character> chars = charController.GetCharacter();

            foreach (User user in users)
            {
                var charactersByUser = charController.GetCharacter().Where(character => character.UserId.Equals(user.Id)).ToList();
                List<Statistics> statsForCharacter = statController.GetStatistics().Where(stat => charactersByUser.Select(character => character.Id).Contains(stat.CharacterId)).ToList();

                viewModel.Users.Add(user);
                viewModel.Statistics.AddRange(statsForCharacter);
                viewModel.Characters.AddRange(charactersByUser);
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult EditCharacter(int id)
        {
            var character = charController.GetCharacter(id) as OkNegotiatedContentResult<Character>;
            if (character == null)
            {
                ModelState.AddModelError("character_fetch", "Could not find the character in the database");
                return RedirectToAction("AllStats");
            }

            Character characterToEdit = character.Content;
            Statistics statsForCharacter = statController.GetStatistics().Find(stat => stat.CharacterId == id);

            EditCharacterViewModel model = new EditCharacterViewModel
            {
                Id = id,
                CharacterName = characterToEdit.Name,
                Kills = statsForCharacter.Kills,
                Deaths = statsForCharacter.Deaths,
                TotalMoney = statsForCharacter.TotalMoney
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult EditCharacter(int id, EditCharacterViewModel input)
        {
            if (ModelState.IsValid)
            {   
                var character = charController.GetCharacter(id) as OkNegotiatedContentResult<Character>;
                if (character == null)
                {
                    ModelState.AddModelError("character_fetch", "Could not find the character in the database");
                    return RedirectToAction("AllStats");
                }

                Character characterToEdit = character.Content;
                Statistics statsForCharacter = statController.GetStatistics().Find(stat => stat.CharacterId == id);

                characterToEdit.Name = input.CharacterName;
                charController.UpdateCharacter(id, characterToEdit);
                statsForCharacter.Deaths = input.Deaths;
                statsForCharacter.Kills = input.Kills;
                statsForCharacter.TotalMoney = input.TotalMoney;
                statController.UpdateStatistics(statsForCharacter.Id, statsForCharacter);
                ModelState.AddModelError("update_success", "Character successfully updated!");
            }

            return View("EditCharacter", input);
        }

    }
}
