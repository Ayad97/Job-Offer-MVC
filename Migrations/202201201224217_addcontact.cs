namespace ASP_IDENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcontact : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        message = c.String(),
                        ContactID = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Contacts", new[] { "User_Id" });
            DropTable("dbo.Contacts");
        }
    }
}
