using GameWebApplication.Models;
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

        public Equipment AddEquipment(Equipment equipment)
        {
            var createdEquipment = _db.Equipment.Add(equipment);
            _db.SaveChanges();
            return createdEquipment;
        }

        public Equipment UpdateEquipment(int id, Equipment equipment)
        {
            var existingEquipment = _db.Equipment.Find(id);

            if (existingEquipment == null)
            {
                return null;
            }
            existingEquipment.InventoryId = equipment.InventoryId;
            existingEquipment.Name = equipment.Name;

            _db.SaveChanges();

            return existingEquipment;
        }

        public void DeleteEquipment(Equipment equipment)
        {
            _db.Equipment.Remove(equipment);
            _db.SaveChanges();
        }
    }
}