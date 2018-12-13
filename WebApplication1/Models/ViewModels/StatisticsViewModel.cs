using System.Collections.Generic;
using GameWebApplication.Models;

namespace GameWebApplication.ViewModels
{
    public class StatisticsViewModel
    {
        public string UserName { get; set; }
        public List<Character> Characters { get; set; }
        public List<Statistics> Statistics { get; set; }
    }
}