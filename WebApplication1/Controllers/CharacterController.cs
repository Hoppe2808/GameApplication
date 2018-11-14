using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GameWebApplication.Models;

namespace GameWebApplication.Controllers
{
    public class CharacterController : ApiController
    {
        private GameWebApplicationContext db = new GameWebApplicationContext();

        // GET: api/Players
        public IQueryable<Character> GetCharacters()
        {
            return db.Characters;
        }

        // GET: api/Players/5
        [ResponseType(typeof(Character))]
        public async Task<IHttpActionResult> GetCharacter(int id)
        {
            Character character = await db.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            return Ok(character);
        }

        // PUT: api/Players/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCharacter(int id, Character character)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != character.ID)
            {
                return BadRequest();
            }

            db.Entry(character).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Players
        [ResponseType(typeof(Character))]
        public async Task<IHttpActionResult> PostCharacter(Character character)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Characters.Add(character);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = character.ID }, character);
        }

        // DELETE: api/Players/5
        [ResponseType(typeof(Character))]
        public async Task<IHttpActionResult> DeleteCharacter(int id)
        {
            Character character = await db.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            db.Characters.Remove(character);
            await db.SaveChangesAsync();

            return Ok(character);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CharacterExists(int id)
        {
            return db.Characters.Count(e => e.ID == id) > 0;
        }
    }
}