using GameWebApplication.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

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

        public void AddInventory(Inventory inventory)
        {
            _db.Inventory.Add(inventory);
        }

        public bool UpdateInventory(int id, Inventory inventory)
        {
            _db.Entry(inventory).State = EntityState.Modified;

            try
            {
                _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists(id))
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

        public void DeleteInventory(Inventory inventory)
        {
            _db.Inventory.Remove(inventory);
        }

        private bool InventoryExists(int id)
        {
            return _db.Inventory.Count(e => e.Id == id) > 0;
        }
    }
}