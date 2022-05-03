namespace ASP_IDENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcontacts : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Contacts", new[] { "User_Id" });
            DropColumn("dbo.Contacts", "ContactID");
            RenameColumn(table: "dbo.Contacts", name: "User_Id", newName: "ContactID");
            AlterColumn("dbo.Contacts", "ContactID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Contacts", "ContactID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Contacts", new[] { "ContactID" });
            AlterColumn("dbo.Contacts", "ContactID", c => c.String());
            RenameColumn(table: "dbo.Contacts", name: "ContactID", newName: "User_Id");
            AddColumn("dbo.Contacts", "ContactID", c => c.String());
            CreateIndex("dbo.Contacts", "User_Id");
        }
    }
}
