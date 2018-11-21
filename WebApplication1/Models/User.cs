using System.ComponentModel.DataAnnotations;

namespace GameWebApplication.Models
{
    public class User : BaseModel
    {
        [Required]
        public string Username { get; set; }
        public string Password { get; set; }

    }
}