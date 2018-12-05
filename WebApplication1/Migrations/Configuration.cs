using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using GameWebApplication.Models;
using Microsoft.AspNet.Identity.Owin;

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
            var userManager = GetOwinContext().GetUserManager<AppUserManager>();
            User usr1 = new User { UserName = "Sebastian"};
            User usr2 = new User { UserName = "Rune"};
            userManager.CreateAsync(usr1, "123");
            userManager.CreateAsync(usr2, "456");

            Inventory inventory1 = new Inventory { Gold = 30 };
            Inventory inventory2 = new Inventory { Gold = 231 };

            if (context.Inventory.Any())
            {
                context.Inventory.Add(inventory1); context.Inventory.Add(inventory2);
            }

            Character character1 = new Character { Name = "MonsterSlayer", User = usr2, Inventory = inventory1 };
            Character character2 = new Character { Name = "Kirneh", User = usr1, Inventory = inventory2 };

            if (!context.Characters.Any())
            {
                context.Characters.Add(character1); context.Characters.Add(character2);
            }

            Equipment item1 = new Equipment { Name = "Reaper of Souls", Inventory = inventory1 };
            Equipment item2 = new Equipment { Name = "Psykosvaerd", Inventory = inventory1 };

            if (context.Equipment.Any())
            {
                context.Equipment.Add(item1); context.Equipment.Add(item2);
            }

            context.SaveChanges();
        }
    }
}
