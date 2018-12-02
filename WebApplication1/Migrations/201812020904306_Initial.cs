namespace GameWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        InventoryId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inventories", t => t.InventoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.InventoryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Gold = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        InventoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inventories", t => t.InventoryId, cascadeDelete: true)
                .Index(t => t.InventoryId);
            
            CreateTable(
                "dbo.Statistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Kills = c.Int(nullable: false),
                        Deaths = c.Int(nullable: false),
                        TotalMoney = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CharacterId, cascadeDelete: true)
                .Index(t => t.CharacterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Statistics", "CharacterId", "dbo.Users");
            DropForeignKey("dbo.Equipments", "InventoryId", "dbo.Inventories");
            DropForeignKey("dbo.Characters", "UserId", "dbo.Users");
            DropForeignKey("dbo.Characters", "InventoryId", "dbo.Inventories");
            DropIndex("dbo.Statistics", new[] { "CharacterId" });
            DropIndex("dbo.Equipments", new[] { "InventoryId" });
            DropIndex("dbo.Characters", new[] { "UserId" });
            DropIndex("dbo.Characters", new[] { "InventoryId" });
            DropTable("dbo.Statistics");
            DropTable("dbo.Equipments");
            DropTable("dbo.Users");
            DropTable("dbo.Inventories");
            DropTable("dbo.Characters");
        }
    }
}
