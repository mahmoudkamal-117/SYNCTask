namespace SYNCTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreationDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "CreationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "CreationDate");
        }
    }
}
