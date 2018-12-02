﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using GameWebApplication.DataAccessObjects;
using GameWebApplication.Models;

namespace GameWebApplication.Controllers
{
    public class CharacterController : ApiController
    {
        private readonly CharacterDao _equipmentDao = new CharacterDao();

        public List<Character> GetCharacter()
        {
            return _equipmentDao.GetCharacters().ToList();
        }

        // GET: api/Characters/5
        [ResponseType(typeof(Character))]
        public IHttpActionResult GetCharacter(int id)
        {
            var equipment = _equipmentDao.GetCharacter(id);
            if (equipment == null)
            {
                return NotFound();
            }
            return Ok(equipment);
        }

        // PUT: api/Characters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCharacter(int id, Character equipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != equipment.Id)
            {
                return BadRequest();
            }

            bool isUpdated = _equipmentDao.UpdateCharacter(id, equipment);

            if (!isUpdated)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Characters
        [ResponseType(typeof(Character))]
        public IHttpActionResult PostCharacter(Character equipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _equipmentDao.AddCharacter(equipment);

            return CreatedAtRoute("DefaultApi", new { id = equipment.Id }, equipment);
        }

        // DELETE: api/Characters/5
        [ResponseType(typeof(Character))]
        public IHttpActionResult DeleteCharacter(int id)
        {
            Character equipment = _equipmentDao.GetCharacter(id);
            if (equipment == null)
            {
                return NotFound();
            }

            _equipmentDao.DeleteCharacter(equipment);

            return Ok(equipment);
        }
        /*
        public ActionResult InventoriesPage()
        {
            ViewBag.Title = "Inventories Page";
            
        }*/
    }
}