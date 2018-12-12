using GameWebApplication.Models;
using System.Linq;
using System.Data.Entity;

namespace GameWebApplication.DataAccessObjects
{
    public class InventoryDao
    {
        private readonly GameWebApplicationContext _db = new GameWebApplicationContext();

        // GET: api/Inventory
        public IQueryable<Inventory> GetInventory()
        {
            return _db.Inventory;
        }

        public Inventory GetInventory(int id)
        {
            return _db.Inventory.Find(id);
        }

        public Inventory GetInventoryWithEquipment(int id)
        {
            return _db.Inventory.Include(i => i.Equipments).Single(i => i.Id == id);
        }

        public Inventory AddInventory(Inventory inventory)
        {
            var createdInventory = _db.Inventory.Add(inventory);
            _db.SaveChanges();
            return createdInventory;
        }

        public Inventory UpdateInventory(int id, Inventory inventory)
        {
            var existingInventory = _db.Inventory.Find(id);

            if (existingInventory == null)
            {
                return null;
            }
            existingInventory.Gold = inventory.Gold;

            _db.SaveChanges();

            return existingInventory;
        }

        public void DeleteInventory(Inventory inventory)
        {
            _db.Inventory.Remove(inventory);
            _db.SaveChanges();
        }
    }
}