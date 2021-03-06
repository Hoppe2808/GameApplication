﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameWebApplication.Models
{
    public class Inventory : BaseModel
    {
        [Required]
        public int Gold { get; set; }
        
        public ICollection<Equipment> Equipments { get; set; }
    }
}