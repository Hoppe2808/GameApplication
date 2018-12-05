using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameWebApplication.Models
{
    public class User : IdentityUser
    {

        public ICollection<Character> Characters { get; set; }
    }
}