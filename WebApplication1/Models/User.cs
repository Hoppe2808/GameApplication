using System.ComponentModel.DataAnnotations;

namespace GameWebApplication.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public string Password { get; set; }

    }
}