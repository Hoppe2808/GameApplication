using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using GameWebApplication.Controllers.Data;
using GameWebApplication.Models;
using GameWebApplication.Models.ViewModels;
using GameWebApplication.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace GameWebApplication.Controllers.Views
{
    public class InventoryController : Controller
    {
        private CharacterController charController = new CharacterController();
        private Data.InventoryController inventoryController = new Data.InventoryController();

        private AppUserManager userManager;

        [Route("Inventory/InventoryPage")]
        public ActionResult InventoryPage(InventoryViewModel viewModel)
        {
            userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            string userId = authManager.User.Identity.GetUserId();
            viewModel.characters = charController.GetCharacter().Where(character => character.UserId.Equals(userId)).ToList();
            foreach (Character character in viewModel.characters)
            {
                try
                {
                    var inv = inventoryController.GetInventoryWithEquipment(character.InventoryId) as OkNegotiatedContentResult<Inventory>;
                    if (inv != null)
                    {
                        character.Inventory = inv.Content;
                    }
                    else
                    {
                        character.Inventory = new Inventory();
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty,
                        ex.Message);
                }

            }
            var test = Request.Form["selectedCharacter"];
            if (Request.Form["selectedCharacter"] != null)
                viewModel.selectedCharacter = viewModel.characters.Where(character => character.Id.Equals(Int32.Parse(Request.Form["selectedCharacter"].ToString()))).First();

            return View(viewModel);
        }
    }
}
