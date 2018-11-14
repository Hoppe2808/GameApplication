using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GameWebApplication.Models;

namespace GameWebApplication.Models
{
    public class Inventory
    {
        public int ID { get; set; }
        [Required]
        public int Gold { get; set; }
        public ICollection<Item> Items { get; set; }

        //Foreign key
        public int CharacterID { get; set; }
        //Navigation property
        [Required]
        public Character character { get; set; }

    }
}