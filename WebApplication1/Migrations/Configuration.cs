using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using GameWebApplication.Models;

namespace GameWebApplication.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<GameWebApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GameWebApplicationContext context)
        {
            User usr1 = new User { Username = "Sebastian", Password = "123" };
            User usr2 = new User { Username = "Rune", Password = "abc" };
            if (!context.Users.Any())
            {
                context.Users.Add(usr1); context.Users.Add(usr1);
            }

            Character character1 = new Character { Name = "MonsterSlayer", UserId = 1, User = usr1 };
            Character character2 = new Character { Name = "Kirneh", UserId = 2, User = usr2 };

            if (!context.Characters.Any())
            {
                context.Characters.Add(character1); context.Characters.Add(character2);
            }

            Item item1 = new Item { Name = "Reaper of Souls" };
            Item item2 = new Item { Name = "Psykosværd" };

            if (context.Item.Any())
            {
                context.Item.Add(item1); context.Item.Add(item2);
            }

            Inventory inventory1 = new Inventory {Character = character1, CharacterId = character1.Id, Gold = 30, Items = new List<Item> {item1, item2}};
            Inventory inventory2 = new Inventory { Character = character2, CharacterId = character2.Id, Gold = 30, Items = new List<Item> { item1 } };

            if (context.Inventory.Any())
            {
                context.Inventory.Add(inventory1); context.Inventory.Add(inventory2);
            }


            context.SaveChanges();
        }
    }
}
