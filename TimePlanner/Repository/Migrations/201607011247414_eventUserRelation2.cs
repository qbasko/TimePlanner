namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventUserRelation2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.EventUsers", new[] { "EventId" });
            DropIndex("dbo.EventUsers", new[] { "UserId" });
            AlterColumn("dbo.EventUsers", "EventId", c => c.String(maxLength: 128));
            AlterColumn("dbo.EventUsers", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.EventUsers", "EventId");
            CreateIndex("dbo.EventUsers", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.EventUsers", new[] { "UserId" });
            DropIndex("dbo.EventUsers", new[] { "EventId" });
            AlterColumn("dbo.EventUsers", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.EventUsers", "EventId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.EventUsers", "UserId");
            CreateIndex("dbo.EventUsers", "EventId");
        }
    }
}
