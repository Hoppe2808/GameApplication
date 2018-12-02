using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using GameWebApplication.DataAccessObjects;
using GameWebApplication.Models;

namespace GameWebApplication.Controllers
{
    public class InventoryController : ApiController
    {
        private readonly InventoryDao _inventoryDao = new InventoryDao();

        public List<Inventory> GetInventory()
        {
            return _inventoryDao.GetInventory().ToList();
        }

        // GET: api/Inventorys/5
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

        // PUT: api/Inventorys/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInventory(int id, Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventory.Id)
            {
                return BadRequest();
            }

            bool isUpdated = _inventoryDao.UpdateInventory(id, inventory);

            if (!isUpdated)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Inventorys
        [ResponseType(typeof(Inventory))]
        public IHttpActionResult PostInventory(Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _inventoryDao.AddInventory(inventory);

            return CreatedAtRoute("DefaultApi", new { id = inventory.Id }, inventory);
        }

        // DELETE: api/Inventorys/5
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