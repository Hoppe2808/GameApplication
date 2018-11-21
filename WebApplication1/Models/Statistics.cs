using System.ComponentModel.DataAnnotations;

namespace GameWebApplication.Models
{
    public class Statistics : BaseModel
    {
        [Required]
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int TotalMoney { get; set; }

        //Foreign key
        public int CharacterId { get; set; }
        //Navigation property
        public User Character { get; set; }

    }
}