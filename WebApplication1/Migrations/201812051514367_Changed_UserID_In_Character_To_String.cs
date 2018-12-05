namespace GameWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changed_UserID_In_Character_To_String : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Characters", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Characters", new[] { "User_Id" });
            DropColumn("dbo.Characters", "UserId");
            RenameColumn(table: "dbo.Characters", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Characters", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Characters", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Characters", "UserId");
            AddForeignKey("dbo.Characters", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Characters", new[] { "UserId" });
            AlterColumn("dbo.Characters", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Characters", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Characters", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Characters", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Characters", "User_Id");
            AddForeignKey("dbo.Characters", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
