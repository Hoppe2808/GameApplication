using GameWebApplication.Models;
using System.Linq;

namespace GameWebApplication.DataAccessObjects
{
    public class UserDao
    {
        private readonly GameWebApplicationContext _db = new GameWebApplicationContext();

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return _db.Users;
        }

        public User GetUser(string id)
        {
            return _db.Users.Find(id);
        }

        public User AddUser(User user)
        {
            var createdUser = _db.Users.Add(user);
            _db.SaveChanges();
            return createdUser;
        }

        public bool UpdateUser(string id, User user)
        {
            var existingUser = _db.Users.Find(id);

            if (existingUser == null)
            {
                return null;
            }
            existingUser.Password = user.Password;
            existingUser.Username = user.Username;

            _db.SaveChanges();

            return existingUser;
        }

        public void DeleteUser(User user)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        private bool UserExists(string id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}