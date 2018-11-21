﻿using System.ComponentModel.DataAnnotations;

namespace GameWebApplication.Models
{
    public class Character : BaseModel
    {
        [Required]
        public string Name { get; set; }
        public Inventory Inventory { get; set; }

        //Foreign key
        public int UserId { get; set; }
        //Navigation property
        [Required]
        public User User { get; set; }

    }
}