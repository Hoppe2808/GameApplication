namespace GameWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStatisticsForeignKeyToCharacters : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Statistics", "CharacterId", "dbo.Users");
            AddForeignKey("dbo.Statistics", "CharacterId", "dbo.Characters");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Statistics", "CharacterId", "dbo.Characters");
            AddForeignKey("dbo.Statistics", "CharacterId", "dbo.Users");
        }
    }
}
