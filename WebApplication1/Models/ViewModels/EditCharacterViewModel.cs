using System.ComponentModel;

namespace GameWebApplication.Models.ViewModels
{
    public class EditCharacterViewModel
    {
        public int Id { get; set; }
        public string CharacterName { get; set; }
        public int Deaths { get; set; }
        public int Kills { get; set; }
        public int TotalMoney { get; set; }
    }
}