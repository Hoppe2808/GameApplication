namespace GameWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update001 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Items", newName: "Equipments");
            DropForeignKey("dbo.Equipments", "InventoryId", "dbo.Inventories");
            DropIndex("dbo.Equipments", new[] { "InventoryId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Equipments", "InventoryId");
            AddForeignKey("dbo.Items", "InventoryId", "dbo.Inventories", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Equipments", newName: "Items");
        }
    }
}
