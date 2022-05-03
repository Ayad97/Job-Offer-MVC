namespace ASP_IDENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testenonialss : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Testemonials", "Category_id", "dbo.Categories");
            DropIndex("dbo.Testemonials", new[] { "Category_id" });
            DropColumn("dbo.Testemonials", "Category_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Testemonials", "Category_id", c => c.Int());
            CreateIndex("dbo.Testemonials", "Category_id");
            AddForeignKey("dbo.Testemonials", "Category_id", "dbo.Categories", "id");
        }
    }
}
