using System.Collections;
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

            Inventory inventory1 = new Inventory { Gold = 30 };
            Inventory inventory2 = new Inventory { Gold = 231 };

            if (context.Inventory.Any())
            {
                context.Inventory.Add(inventory1); context.Inventory.Add(inventory2);
            }

            Character character1 = new Character { Name = "MonsterSlayer", UserId = usr2.Id, InventoryId = inventory1.Id };
            Character character2 = new Character { Name = "Kirneh", UserId = usr1.Id, InventoryId = inventory2.Id };

            if (!context.Characters.Any())
            {
                context.Characters.Add(character1); context.Characters.Add(character2);
            }

            Equipment item1 = new Equipment { Name = "Reaper of Souls", InventoryId = inventory1.Id };
            Equipment item2 = new Equipment { Name = "Psykosvaerd", InventoryId = inventory1.Id };

            if (context.Equipment.Any())
            {
                context.Equipment.Add(item1); context.Equipment.Add(item2);
            }

            context.SaveChanges();
        }
    }
}
