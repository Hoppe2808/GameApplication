using GameWebApplication.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace GameWebApplication.DataAccessObjects
{
    public class CharacterDao
    {
        private readonly GameWebApplicationContext _db = new GameWebApplicationContext();

        // GET: api/Users
        public IQueryable<Character> GetCharacters()
        {
            return _db.Characters;
        }

        public Character GetCharacter(int id)
        {
            return _db.Characters.Find(id);
        }

        public void AddCharacter(Character character)
        {
            _db.Characters.Add(character);
        }

        public bool UpdateCharacter(int id, Character character)
        {
            _db.Entry(character).State = EntityState.Modified;

            try
            {
                _db.SaveChangesAsync();
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
            _db.Characters.Remove(character);
        }

        //Inventory

        public Inventory GetInventoryForCharacter(Character character)
        {
            int inventoryId = character.InventoryId;
            return _db.Inventory.Find(inventoryId);
        }

        private bool CharacterExists(int id)
        {
            return _db.Characters.Count(e => e.Id == id) > 0;
        }
    }
}