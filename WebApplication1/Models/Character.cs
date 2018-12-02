using System.ComponentModel.DataAnnotations;

namespace GameWebApplication.Models
{
    public class Character : BaseModel
    {
        [Required]
        public string Name { get; set; }

        //Foreign key
        [Required]
        public int InventoryId { get; set; }
        public int UserId { get; set; }
        //Navigation property
        public User User { get; set; }
        public Inventory Inventory { get; set; }
    }
}