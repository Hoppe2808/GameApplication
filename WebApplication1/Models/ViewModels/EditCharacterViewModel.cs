using System.ComponentModel;

namespace GameWebApplication.Models.ViewModels
{
    public class EditCharacterViewModel
    {
        public string CharacterName { get; set; }
        public int Deaths { get; set; }
        public int Kills { get; set; }
        public int TotalMoney { get; set; }
        public Character Character { get; set; }
        public Statistics Statistics { get; set; }
    }
}