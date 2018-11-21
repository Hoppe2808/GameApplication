using GameWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace GameWebApplication.DataAccessObjects
{
    public class UserDAO
    {
        private GameWebApplicationContext db = new GameWebApplicationContext();

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        public User GetUser(int id)
        {
            return db.Users.Find(id);
        }
        
        public void AddUser(User user)
        {
            db.Users.Add(user);
        }

        public bool UpdateUser(int id, User user)
        {
            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        public void DeleteUser(User user)
        {
            db.Users.Remove(user);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}