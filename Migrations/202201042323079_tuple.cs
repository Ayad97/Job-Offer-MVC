namespace ASP_IDENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tuple : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "joinclasses_ID", "dbo.joinclasses");
            DropForeignKey("dbo.Testemonials", "joinclasses_ID", "dbo.joinclasses");
            DropIndex("dbo.Categories", new[] { "joinclasses_ID" });
            DropIndex("dbo.Testemonials", new[] { "joinclasses_ID" });
            DropColumn("dbo.Categories", "joinclasses_ID");
            DropColumn("dbo.Testemonials", "joinclasses_ID");
            DropTable("dbo.joinclasses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.joinclasses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Testemonials", "joinclasses_ID", c => c.Int());
            AddColumn("dbo.Categories", "joinclasses_ID", c => c.Int());
            CreateIndex("dbo.Testemonials", "joinclasses_ID");
            CreateIndex("dbo.Categories", "joinclasses_ID");
            AddForeignKey("dbo.Testemonials", "joinclasses_ID", "dbo.joinclasses", "ID");
            AddForeignKey("dbo.Categories", "joinclasses_ID", "dbo.joinclasses", "ID");
        }
    }
}
