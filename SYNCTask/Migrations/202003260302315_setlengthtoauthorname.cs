namespace SYNCTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setlengthtoauthorname : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "Name", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "Name", c => c.String(nullable: false));
        }
    }
}
