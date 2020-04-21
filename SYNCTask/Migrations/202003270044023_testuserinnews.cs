namespace SYNCTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testuserinnews : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.News", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.News", new[] { "UserId" });
            AlterColumn("dbo.News", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.News", "UserId");
            AddForeignKey("dbo.News", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.News", new[] { "UserId" });
            AlterColumn("dbo.News", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.News", "UserId");
            AddForeignKey("dbo.News", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
