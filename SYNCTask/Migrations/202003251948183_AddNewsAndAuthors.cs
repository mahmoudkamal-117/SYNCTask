namespace SYNCTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewsAndAuthors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        NewsDescription = c.String(nullable: false),
                        Image = c.String(),
                        PublicationDate = c.DateTime(),
                        CreationDate = c.DateTime(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        UserId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.News", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.News", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.News", new[] { "AuthorId" });
            DropTable("dbo.News");
            DropTable("dbo.Authors");
        }
    }
}
