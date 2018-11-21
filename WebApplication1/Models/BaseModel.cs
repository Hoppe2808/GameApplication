using System.ComponentModel.DataAnnotations;

namespace GameWebApplication.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
    }
}