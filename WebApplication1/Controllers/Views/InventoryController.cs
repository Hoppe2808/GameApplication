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
        [Route("Inventory/InventoryPage")]
        public ActionResult InventoryPage()
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            InventoryViewModel viewModel = new InventoryViewModel();
            CharacterController charController = new CharacterController();
            Data.InventoryController inventoryController = new Data.InventoryController();

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

            return View(viewModel);
        }
    }
}
