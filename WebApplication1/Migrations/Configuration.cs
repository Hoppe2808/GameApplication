namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.GameWebApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication1.Models.GameWebApplicationContext context)
        {
            context.Users.AddOrUpdate(x => x.ID,
                new User() { ID = 1, Username = "Sebastian", Password = "123" },
                new User() { ID = 2, Username = "Henrik", Password = "abc" });

            context.Players.AddOrUpdate(x => x.ID,
                new Character() { ID = 1, Name = "MonsterSlayer", UserID = 1 },
                new Character() { ID = 2, Name = "Kirneh", UserID = 2 });

        }
    }
}
