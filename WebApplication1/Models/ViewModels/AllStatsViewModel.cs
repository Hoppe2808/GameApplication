using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameWebApplication.Models.ViewModels
{
    public class AllStatsViewModel
    {
        public List<string> Usernames { get; set; }
        public List<Statistics> Statistics { get; set; }
    }
}