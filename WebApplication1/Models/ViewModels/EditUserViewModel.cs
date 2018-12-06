using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameWebApplication.Models.ViewModels
{
    public class EditUserViewModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string OldPassword { get; set; }
    }
}