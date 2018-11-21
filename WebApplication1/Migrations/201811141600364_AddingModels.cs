namespace GameWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingModels : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Players", newName: "Characters");
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Gold = c.Int(nullable: false),
                        CharacterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Characters", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ItemID = c.Int(nullable: false),
                        Inventory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Inventories", t => t.Inventory_ID)
                .Index(t => t.Inventory_ID);
            
            CreateTable(
                "dbo.Statistics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Kills = c.Int(nullable: false),
                        Deaths = c.Int(nullable: false),
                        TotalMoney = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Statistics", "UserID", "dbo.Users");
            DropForeignKey("dbo.Items", "Inventory_ID", "dbo.Inventories");
            DropForeignKey("dbo.Inventories", "ID", "dbo.Characters");
            DropIndex("dbo.Statistics", new[] { "UserID" });
            DropIndex("dbo.Items", new[] { "Inventory_ID" });
            DropIndex("dbo.Inventories", new[] { "ID" });
            DropTable("dbo.Statistics");
            DropTable("dbo.Items");
            DropTable("dbo.Inventories");
            RenameTable(name: "dbo.Characters", newName: "Players");
        }
    }
}
