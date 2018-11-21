using GameWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace GameWebApplication.DataAccessObjects
{
    public class CharacterDAO
    {
        private GameWebApplicationContext db = new GameWebApplicationContext();

        // GET: api/Users
        public IQueryable<Character> GetCharacters()
        {
            return db.Characters;
        }

        public Character GetCharacter(int id)
        {
            return db.Characters.Find(id);
        }

        public void AddCharacter(Character character)
        {
            db.Characters.Add(character);
        }

        public bool UpdateCharacter(int id, Character character)
        {
            db.Entry(character).State = EntityState.Modified;

            try
            {
                db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
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

        public void DeleteCharacter(Character character)
        {
            db.Characters.Remove(character);
        }

        //Inventory

        public Inventory GetInventoryForCharacter(Character character)
        {
            int inventoryId = character.getInventoryId();
            return db.Inventory.Find(inventoryId)
        }

        private bool CharacterExists(int id)
        {
            return db.Characters.Count(e => e.Id == id) > 0;
        }
    }
}