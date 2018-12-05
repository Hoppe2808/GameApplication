using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using GameWebApplication.DataAccessObjects;
using GameWebApplication.Models;

namespace GameWebApplication.Controllers.Data
{
    public class UsersController : ApiController
    {
        private readonly UserDao _userDao = new UserDao();

        public List<User> GetUsers()
        {
            return _userDao.GetUsers().ToList();
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            var user = _userDao.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        [HttpPost]
        public IHttpActionResult CreateUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_userDao.AddUser(user));
        }

        // PUT: api/Users/5
        [HttpPut]
        public IHttpActionResult UpdateUser(int id, User userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedUser = _userDao.UpdateUser(id, userDto);

            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = _userDao.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            _userDao.DeleteUser(user);

            return Ok();
        }
        /*
        public ActionResult UsersPage()
        {
            ViewBag.Title = "Users Page";
            
        }*/
    }
}