using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GameWebApplication.Models;

namespace GameWebApplication.Models
{
    public class Statistics
    {
        public int ID { get; set; }
        [Required]
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int TotalMoney { get; set; }

        //Foreign key
        public int UserID { get; set; }
        //Navigation property
        public User user { get; set; }

    }
}