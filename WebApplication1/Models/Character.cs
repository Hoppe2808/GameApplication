using System.Collections.Generic;
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
        [Required]
        public string UserId { get; set; }
        //Navigation property
        public Inventory Inventory { get; set; }
        public User User { get; set; }
        public ICollection<Statistics> Statistics { get; set; }
    }
}