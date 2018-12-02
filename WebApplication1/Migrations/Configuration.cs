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
                context.Users.Add(usr1); context.Users.Add(usr2);
            }

            Inventory inventory1 = new Inventory { Gold = 30 };
            Inventory inventory2 = new Inventory { Gold = 231 };

            if (!context.Inventory.Any())
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

            if (!context.Equipment.Any())
            {
                context.Equipment.Add(item1); context.Equipment.Add(item2);
            }

            Statistics char1Stats = new Statistics { Character = character1, Deaths = 2, Kills = 500, TotalMoney = 4000};
            Statistics char2Stats = new Statistics { Character = character2, Deaths = 0, Kills = 12, TotalMoney = 44 };

            if (!context.Statistics.Any())
            {
                context.Statistics.Add(char1Stats); context.Statistics.Add(char2Stats);
            }

            context.SaveChanges();
        }
    }
}
