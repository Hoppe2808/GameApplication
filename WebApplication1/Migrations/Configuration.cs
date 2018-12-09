using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using GameWebApplication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            if (!context.Roles.Any(r => r.Name == "admin") && !context.Roles.Any(r => r.Name == "default"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "admin" };
                var roleDefault = new IdentityRole { Name = "default" };

                roleManager.Create(role);
                roleManager.Create(roleDefault);
            }

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User { UserName = "admin" };

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                userManager.Create(user, "test1234");
                userManager.AddToRole(user.Id, "Admin");
            }

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

            Character character1 = new Character { Name = "MonsterSlayer", UserId = user.Id, Inventory = inventory1 };
            Character character2 = new Character { Name = "Kirneh", UserId = user.Id, Inventory = inventory2 };
            Character character3 = new Character { Name = "Jaa", UserId = user.Id, Inventory = inventory3 };
            Character character4 = new Character { Name = "Neee", UserId = user.Id, Inventory = inventory2 };
            Character character5 = new Character { Name = "ADff", UserId = user.Id, Inventory = inventory5 };
            Character character6 = new Character { Name = "Redrum", UserId = user.Id, Inventory = inventory6 };

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

            context.SaveChanges();

            Statistics char1Stats = new Statistics { CharacterId = character1.Id, Deaths = 2, Kills = 500, TotalMoney = 4000 };
            Statistics char2Stats = new Statistics { CharacterId = character2.Id, Deaths = 0, Kills = 12, TotalMoney = 44 };
            Statistics char3Stats = new Statistics { CharacterId = character3.Id, Deaths = 0, Kills = 12, TotalMoney = 44 };
            Statistics char4Stats = new Statistics { CharacterId = character4.Id, Deaths = 0, Kills = 12, TotalMoney = 44 };

            if (!context.Statistics.Any())
            {
                context.Statistics.Add(char1Stats); context.Statistics.Add(char2Stats); context.Statistics.Add(char3Stats); context.Statistics.Add(char4Stats);// context.Statistics.Add(char5Stats); context.Statistics.Add(char6Stats);
            }

            context.SaveChanges();
        }
    }
}
