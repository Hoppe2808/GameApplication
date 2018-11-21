using System.Data.Entity;

namespace GameWebApplication.Models
{
    public class GameWebApplicationContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public GameWebApplicationContext() : base("GameWebApplicationContext")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Character> Characters { get; set; }

        public DbSet<Statistics> Statistics { get; set; }

        public DbSet<Inventory> Inventory { get; set; }

        public DbSet<Equipment> Equipment { get; set; }

        public DbSet<Item> Item { get; set; }
    }
}
