using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using GameWebApplication.DataAccessObjects;
using GameWebApplication.Models;

namespace GameWebApplication.Controllers
{
    public class CharacterController : ApiController
    {
        private readonly CharacterDao _characterDao = new CharacterDao();

        public List<Character> GetCharacter()
        {
            return _characterDao.GetCharacters().ToList();
        }

        // GET: api/Characters/5
        [ResponseType(typeof(Character))]
        public IHttpActionResult GetCharacter(int id)
        {
            var character = _characterDao.GetCharacter(id);
            if (character == null)
            {
                return NotFound();
            }
            return Ok(character);
        }

        // POST: api/Characters
        [ResponseType(typeof(Character))]
        public IHttpActionResult PostCharacter(Character character)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_characterDao.AddCharacter(character));
        }

        // PUT: api/Characters/5
        [HttpPut]
        public IHttpActionResult UpdateCharacter(int id, Character character)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedCharacter = _characterDao.UpdateCharacter(id, character);

            if (updatedCharacter == null)
            {
                return NotFound();
            }
            return Ok(updatedCharacter);
        }

        // DELETE: api/Characters/5
        [ResponseType(typeof(Character))]
        public IHttpActionResult DeleteCharacter(int id)
        {
            Character character = _characterDao.GetCharacter(id);
            if (character == null)
            {
                return NotFound();
            }

            _characterDao.DeleteCharacter(character);

            return Ok(character);
        }
        /*
        public ActionResult InventoriesPage()
        {
            ViewBag.Title = "Inventories Page";
            
        }*/
    }
}