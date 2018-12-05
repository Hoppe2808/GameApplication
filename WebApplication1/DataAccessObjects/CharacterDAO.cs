using GameWebApplication.Models;
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

        public Character AddCharacter(Character character)
        {
            var createdCharacter = _db.Characters.Add(character);
            _db.SaveChanges();
            return createdCharacter;
        }

        public Character UpdateCharacter(int id, Character character)
        {
            var existingCharacter = _db.Characters.Find(id);

            if (existingCharacter == null)
            {
                return null;
            }
            existingCharacter.InventoryId = character.InventoryId;
            existingCharacter.Name = character.Name;
            existingCharacter.UserId = character.UserId;

            _db.SaveChanges();

            return existingCharacter;
        }

        public void DeleteCharacter(Character character)
        {
            _db.Characters.Remove(character);
            _db.SaveChanges();
        }
    }
}