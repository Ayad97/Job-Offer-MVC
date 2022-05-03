namespace ASP_IDENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.jointuples", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.jointuples", "User_Id");
            AddForeignKey("dbo.jointuples", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.jointuples", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.jointuples", new[] { "User_Id" });
            DropColumn("dbo.jointuples", "User_Id");
        }
    }
}
