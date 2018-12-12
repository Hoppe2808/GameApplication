using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameWebApplication.Models.ViewModels
{
    public class InventoryViewModel
    {
        public IEnumerable<Character> characters { get; set; }
        public Character selectedCharacter { get; set; }
    }
}