using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GameWebApplication.DataAccessObjects;
using GameWebApplication.Models;

namespace GameWebApplication.Controllers
{
    public class UsersController : ApiController
    {
        UserDAO userDAO = new UserDAO();

        public List<User> GetUsers()
        {
            return userDAO.GetUsers().ToList();
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            var user = userDAO.GetUser(id);
            if(user == null)
            {
                return null;
            }
            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            bool isUpdated = userDAO.UpdateUser(id, user);

            if (!isUpdated)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            userDAO.AddUser(user);

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            User user = userDAO.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            userDAO.DeleteUser(user);

            return Ok(user);
        }
    }
}