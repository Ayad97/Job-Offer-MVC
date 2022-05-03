namespace ASP_IDENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTeam : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeamInfoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TeamImage = c.String(),
                        TeamUsername = c.String(),
                        TeamWorkTittle = c.String(),
                        TeamAbout = c.String(),
                        TeamEmailF = c.String(),
                        TeamEmailT = c.String(),
                        TeamEmailI = c.String(),
                        TeamEmailL = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TeamInfoes");
        }
    }
}
