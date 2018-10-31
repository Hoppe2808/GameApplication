using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Player
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        //Foreign key
        public int UserID { get; set; }
        //Navigation property
        public User user { get; set; }

    }
}