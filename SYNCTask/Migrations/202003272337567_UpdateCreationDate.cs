namespace SYNCTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCreationDate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.News", "CreationDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "CreationDate", c => c.DateTime(nullable: false));
        }
    }
}
