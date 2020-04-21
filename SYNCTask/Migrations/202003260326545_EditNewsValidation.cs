namespace SYNCTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditNewsValidation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.News", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.News", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.News", "UserId");
            RenameColumn(table: "dbo.News", name: "ApplicationUser_Id", newName: "UserId");
            AlterColumn("dbo.News", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.News", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.News", "UserId");
            AddForeignKey("dbo.News", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.News", new[] { "UserId" });
            AlterColumn("dbo.News", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.News", "UserId", c => c.String());
            RenameColumn(table: "dbo.News", name: "UserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.News", "UserId", c => c.String());
            CreateIndex("dbo.News", "ApplicationUser_Id");
            AddForeignKey("dbo.News", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
