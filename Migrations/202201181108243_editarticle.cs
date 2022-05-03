namespace ASP_IDENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editarticle : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Articles", new[] { "User_Id" });
            DropColumn("dbo.Articles", "Blog_Id");
            RenameColumn(table: "dbo.Articles", name: "User_Id", newName: "Blog_Id");
            AlterColumn("dbo.Articles", "Blog_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Articles", "Blog_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Articles", new[] { "Blog_Id" });
            AlterColumn("dbo.Articles", "Blog_Id", c => c.String());
            RenameColumn(table: "dbo.Articles", name: "Blog_Id", newName: "User_Id");
            AddColumn("dbo.Articles", "Blog_Id", c => c.String());
            CreateIndex("dbo.Articles", "User_Id");
        }
    }
}
