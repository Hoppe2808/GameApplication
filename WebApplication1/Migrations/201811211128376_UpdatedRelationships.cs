namespace GameWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedRelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inventories", "Id", "dbo.Characters");
            DropForeignKey("dbo.Items", "Inventory_Id", "dbo.Inventories");
            DropIndex("dbo.Inventories", new[] { "Id" });
            DropIndex("dbo.Items", new[] { "Inventory_Id" });
            RenameColumn(table: "dbo.Items", name: "Inventory_Id", newName: "InventoryId");
            RenameColumn(table: "dbo.Statistics", name: "UserId", newName: "CharacterId");
            RenameIndex(table: "dbo.Statistics", name: "IX_UserId", newName: "IX_CharacterId");
            DropPrimaryKey("dbo.Inventories");
            AddColumn("dbo.Characters", "InventoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Inventories", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Items", "InventoryId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Inventories", "Id");
            CreateIndex("dbo.Characters", "InventoryId");
            CreateIndex("dbo.Items", "InventoryId");
            AddForeignKey("dbo.Characters", "InventoryId", "dbo.Inventories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Items", "InventoryId", "dbo.Inventories", "Id", cascadeDelete: true);
            DropColumn("dbo.Inventories", "CharacterId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inventories", "CharacterId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Items", "InventoryId", "dbo.Inventories");
            DropForeignKey("dbo.Characters", "InventoryId", "dbo.Inventories");
            DropIndex("dbo.Items", new[] { "InventoryId" });
            DropIndex("dbo.Characters", new[] { "InventoryId" });
            DropPrimaryKey("dbo.Inventories");
            AlterColumn("dbo.Items", "InventoryId", c => c.Int());
            AlterColumn("dbo.Inventories", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Characters", "InventoryId");
            AddPrimaryKey("dbo.Inventories", "Id");
            RenameIndex(table: "dbo.Statistics", name: "IX_CharacterId", newName: "IX_UserId");
            RenameColumn(table: "dbo.Statistics", name: "CharacterId", newName: "UserId");
            RenameColumn(table: "dbo.Items", name: "InventoryId", newName: "Inventory_Id");
            CreateIndex("dbo.Items", "Inventory_Id");
            CreateIndex("dbo.Inventories", "Id");
            AddForeignKey("dbo.Items", "Inventory_Id", "dbo.Inventories", "Id");
            AddForeignKey("dbo.Inventories", "Id", "dbo.Characters", "Id");
        }
    }
}
