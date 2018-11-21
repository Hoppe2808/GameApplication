namespace GameWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBaseModelAndItemAsAbstract : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Characters", new[] { "UserID" });
            DropIndex("dbo.Inventories", new[] { "ID" });
            DropIndex("dbo.Items", new[] { "Inventory_ID" });
            DropIndex("dbo.Statistics", new[] { "UserID" });
            AddColumn("dbo.Items", "Name", c => c.String());
            CreateIndex("dbo.Characters", "UserId");
            CreateIndex("dbo.Inventories", "Id");
            CreateIndex("dbo.Items", "Inventory_Id");
            CreateIndex("dbo.Statistics", "UserId");
            DropColumn("dbo.Items", "ItemID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "ItemID", c => c.Int(nullable: false));
            DropIndex("dbo.Statistics", new[] { "UserId" });
            DropIndex("dbo.Items", new[] { "Inventory_Id" });
            DropIndex("dbo.Inventories", new[] { "Id" });
            DropIndex("dbo.Characters", new[] { "UserId" });
            DropColumn("dbo.Items", "Name");
            CreateIndex("dbo.Statistics", "UserID");
            CreateIndex("dbo.Items", "Inventory_ID");
            CreateIndex("dbo.Inventories", "ID");
            CreateIndex("dbo.Characters", "UserID");
        }
    }
}
