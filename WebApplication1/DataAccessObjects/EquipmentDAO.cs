using GameWebApplication.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace GameWebApplication.DataAccessObjects
{
    public class EquipmentDao
    {
        private readonly GameWebApplicationContext _db = new GameWebApplicationContext();

        // GET: api/Equipment
        public IQueryable<Equipment> GetEquipments()
        {
            return _db.Equipment;
        }

        public Equipment GetEquipment(int id)
        {
            return _db.Equipment.Find(id);
        }

        public void AddEquipment(Equipment equipment)
        {
            _db.Equipment.Add(equipment);
        }

        public bool UpdateEquipment(int id, Equipment equipment)
        {
            _db.Entry(equipment).State = EntityState.Modified;

            try
            {
                _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentExists(id))
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

        public void DeleteEquipment(Equipment equipment)
        {
            _db.Equipment.Remove(equipment);
        }

        private bool EquipmentExists(int id)
        {
            return _db.Equipment.Count(e => e.Id == id) > 0;
        }
    }
}