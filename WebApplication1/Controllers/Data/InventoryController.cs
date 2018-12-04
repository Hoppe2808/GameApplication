using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using GameWebApplication.DataAccessObjects;
using GameWebApplication.Models;

namespace GameWebApplication.Controllers.Data
{
    public class InventoryController : ApiController
    {
        private readonly InventoryDao _inventoryDao = new InventoryDao();

        public List<Inventory> GetInventories()
        {
            return _inventoryDao.GetInventory().ToList();
        }

        // GET: api/Inventories/5
        [ResponseType(typeof(Inventory))]
        public IHttpActionResult GetInventory(int id)
        {
            var inventory = _inventoryDao.GetInventory(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return Ok(inventory);
        }

        // POST: api/Inventories
        [ResponseType(typeof(Inventory))]
        public IHttpActionResult CreateInventory(Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_inventoryDao.AddInventory(inventory));
        }

        // PUT: api/Inventories/5
        [HttpPut]
        public IHttpActionResult UpdateInventory(int id, Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedInventory = _inventoryDao.UpdateInventory(id, inventory);

            if (updatedInventory == null)
            {
                return NotFound();
            }
            return Ok(updatedInventory);
        }

        // DELETE: api/Inventories/5
        [ResponseType(typeof(Inventory))]
        public IHttpActionResult DeleteInventory(int id)
        {
            Inventory inventory = _inventoryDao.GetInventory(id);
            if (inventory == null)
            {
                return NotFound();
            }

            _inventoryDao.DeleteInventory(inventory);

            return Ok(inventory);
        }
        /*
        public ActionResult InventoriesPage()
        {
            ViewBag.Title = "Inventories Page";
            
        }*/
    }
}