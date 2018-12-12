using System.Collections.Generic;
using GameWebApplication.Models;

namespace GameWebApplication.ViewModels
{
    public class AllStatsViewModel
    {
        public List<User> Users { get; set; }
        public List<Statistics> Statistics { get; set; }
        public List<Character> Characters { get; set; }
    }
}