namespace ASP_IDENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addarticle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        BlogImage = c.String(),
                        BlogTittle = c.String(),
                        BlogArticle = c.String(),
                        Blog_Id = c.String(),
                        ReturnDate = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Articles", new[] { "User_Id" });
            DropTable("dbo.Articles");
        }
    }
}
