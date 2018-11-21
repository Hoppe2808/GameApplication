using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameWebApplication.Models
{
    public class Inventory : BaseModel
    {
        [Required]
        public int Gold { get; set; }
        
        //Navigation property
        public ICollection<Item> Items { get; set; }
    }
}