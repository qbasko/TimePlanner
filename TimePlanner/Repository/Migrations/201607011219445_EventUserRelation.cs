namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventUserRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Events", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "Event_Id" });
            DropIndex("dbo.Events", new[] { "AuthorId" });
            CreateTable(
                "dbo.EventUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        EventId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.EventId)
                .Index(t => t.UserId);
            
            AlterColumn("dbo.Events", "AuthorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Events", "AuthorId");
            AddForeignKey("dbo.Events", "AuthorId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "Event_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Event_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Events", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EventUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EventUsers", "EventId", "dbo.Events");
            DropIndex("dbo.Events", new[] { "AuthorId" });
            DropIndex("dbo.EventUsers", new[] { "UserId" });
            DropIndex("dbo.EventUsers", new[] { "EventId" });
            AlterColumn("dbo.Events", "AuthorId", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.EventUsers");
            CreateIndex("dbo.Events", "AuthorId");
            CreateIndex("dbo.AspNetUsers", "Event_Id");
            AddForeignKey("dbo.Events", "AuthorId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "Event_Id", "dbo.Events", "Id");
        }
    }
}
