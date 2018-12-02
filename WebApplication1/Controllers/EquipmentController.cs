using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        // PUT: api/Equipments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEquipment(int id, Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != equipment.Id)
            {
                return BadRequest();
            }

            bool isUpdated = _equipmentDao.UpdateEquipment(id, equipment);

            if (!isUpdated)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Equipments
        [ResponseType(typeof(Equipment))]
        public IHttpActionResult PostEquipment(Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _equipmentDao.AddEquipment(equipment);

            return CreatedAtRoute("DefaultApi", new { id = equipment.Id }, equipment);
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