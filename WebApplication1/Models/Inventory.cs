using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameWebApplication.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        [Required]
        public int Gold { get; set; }
        public ICollection<Item> Items { get; set; }

        //Foreign key
        public int CharacterId { get; set; }
        //Navigation property
        [Required]
        public Character Character { get; set; }

    }
}