namespace ASP_IDENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditJobModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "UserType", c => c.String());
            CreateIndex("dbo.Jobs", "UserId");
            AddForeignKey("dbo.Jobs", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Jobs", new[] { "UserId" });
            DropColumn("dbo.AspNetUsers", "UserType");
            DropColumn("dbo.Jobs", "UserId");
        }
    }
}
