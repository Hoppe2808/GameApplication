using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using GameWebApplication.DataAccessObjects;
using GameWebApplication.Models;

namespace GameWebApplication.Controllers
{
    public class EquipmentController : ApiController
    {
        private readonly EquipmentDao _equipmentDao = new EquipmentDao();

        public List<Equipment> GetEquipment()
        {
            return _equipmentDao.GetEquipments().ToList();
        }

        // GET: api/Equipments/5
        [ResponseType(typeof(Equipment))]
        public IHttpActionResult GetEquipment(int id)
        {
            var equipment = _equipmentDao.GetEquipment(id);
            if (equipment == null)
            {
                return NotFound();
            }
            return Ok(equipment);
        }

        // POST: api/Equipments
        [ResponseType(typeof(Equipment))]
        public IHttpActionResult CreateEquipment(Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_equipmentDao.AddEquipment(equipment));
        }

        // PUT: api/Equipments/5
        [HttpPut]
        public IHttpActionResult UpdateEquipment(int id, Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedInventory = _equipmentDao.UpdateEquipment(id, equipment);

            if (updatedInventory == null)
            {
                return NotFound();
            }
            return Ok(updatedInventory);
        }

        // DELETE: api/Equipments/5
        [ResponseType(typeof(Equipment))]
        public IHttpActionResult DeleteEquipment(int id)
        {
            Equipment equipment = _equipmentDao.GetEquipment(id);
            if (equipment == null)
            {
                return NotFound();
            }

            _equipmentDao.DeleteEquipment(equipment);

            return Ok(equipment);
        }
        /*
        public ActionResult InventoriesPage()
        {
            ViewBag.Title = "Inventories Page";
            
        }*/
    }
}