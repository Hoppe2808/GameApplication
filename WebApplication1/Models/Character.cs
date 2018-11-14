using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using GameWebApplication.Models;

namespace GameWebApplication.Models
{
    public class Character
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public Inventory Inventory { get; set; }

        //Foreign key
        public int UserID { get; set; }
        //Navigation property
        public User user { get; set; }

    }
}