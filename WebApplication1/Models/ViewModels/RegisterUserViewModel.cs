using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameWebApplication.Models.ViewModels
{
    public class RegisterUserViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public Boolean Admin { get; set; }
    }
}