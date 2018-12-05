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
            //var userManager = GetOwinContext().GetUserManager<AppUserManager>();
            User usr1 = new User { Id = "1", UserName = "Sebastian", PasswordHash = "123456"};
            User usr2 = new User { Id = "2", UserName = "Rune", };
            //userManager.CreateAsync(usr1, "123");
            //userManager.CreateAsync(usr2, "456")
            User usr3 = context.Users.Find("9ba716a5-c9ef-4cbd-9f79-548f80764c3e");

            Inventory inventory1 = new Inventory { Gold = 30 };
            Inventory inventory2 = new Inventory { Gold = 231 };
            Inventory inventory3 = new Inventory { Gold = 234 };
            Inventory inventory4 = new Inventory { Gold = 4 };
            Inventory inventory5 = new Inventory { Gold = 25 };
            Inventory inventory6 = new Inventory { Gold = 76 };

            if (!context.Inventory.Any())
            {
                context.Inventory.Add(inventory1); context.Inventory.Add(inventory2); context.Inventory.Add(inventory3); context.Inventory.Add(inventory4); context.Inventory.Add(inventory5); context.Inventory.Add(inventory6);
            }

            Character character1 = new Character { Name = "MonsterSlayer", UserId = usr3.Id, Inventory = inventory1 };
            Character character2 = new Character { Name = "Kirneh", UserId = usr3.Id, Inventory = inventory2 };
            Character character3 = new Character { Name = "Jaa", UserId = usr3.Id, Inventory = inventory3 };
            Character character4 = new Character { Name = "Neee", UserId = usr3.Id, Inventory = inventory2 };
            Character character5 = new Character { Name = "ADff", UserId = usr3.Id, Inventory = inventory5 };
            Character character6 = new Character { Name = "Redrum", UserId = usr3.Id, Inventory = inventory6 };

            if (!context.Characters.Any())
            {
                context.Characters.Add(character1); context.Characters.Add(character2); context.Characters.Add(character3); context.Characters.Add(character4);
            }

            Equipment item1 = new Equipment { Name = "Reaper of Souls", Inventory = inventory1 };
            Equipment item2 = new Equipment { Name = "Psykosvaerd", Inventory = inventory1 };

            if (!context.Equipment.Any())
            {
                context.Equipment.Add(item1); context.Equipment.Add(item2);
            }

            Statistics char1Stats = new Statistics { Character = character1, Deaths = 2, Kills = 500, TotalMoney = 4000 };
            Statistics char2Stats = new Statistics { Character = character2, Deaths = 0, Kills = 12, TotalMoney = 44 };
            Statistics char3Stats = new Statistics { Character = character3, Deaths = 4, Kills = 0, TotalMoney = 1 };
            Statistics char4Stats = new Statistics { Character = character4, Deaths = 40, Kills = 43, TotalMoney = 0 };
            Statistics char5Stats = new Statistics { Character = character5, Deaths = 70, Kills = 1, TotalMoney = 76 };
            Statistics char6Stats = new Statistics { Character = character6, Deaths = 654, Kills = 0, TotalMoney = 1337 };

            if (!context.Statistics.Any())
            {
                context.Statistics.Add(char1Stats); context.Statistics.Add(char2Stats);// context.Statistics.Add(char3Stats); context.Statistics.Add(char4Stats); context.Statistics.Add(char5Stats); context.Statistics.Add(char6Stats);
            }

            context.SaveChanges();
        }
    }
}
