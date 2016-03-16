namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAuthorAndDate : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Events", new[] { "LocationId" });
            DropIndex("dbo.Events", new[] { "TypeId" });
            AddColumn("dbo.Events", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Locations", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Locations", "AuthorId", c => c.String(maxLength: 128));
            AddColumn("dbo.EventTypes", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.EventTypes", "AuthorId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Events", "LocationId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Events", "TypeId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Events", "LocationId");
            CreateIndex("dbo.Events", "TypeId");
            CreateIndex("dbo.Locations", "AuthorId");
            CreateIndex("dbo.EventTypes", "AuthorId");
            AddForeignKey("dbo.Locations", "AuthorId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.EventTypes", "AuthorId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventTypes", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Locations", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.EventTypes", new[] { "AuthorId" });
            DropIndex("dbo.Locations", new[] { "AuthorId" });
            DropIndex("dbo.Events", new[] { "TypeId" });
            DropIndex("dbo.Events", new[] { "LocationId" });
            AlterColumn("dbo.Events", "TypeId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Events", "LocationId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.EventTypes", "AuthorId");
            DropColumn("dbo.EventTypes", "CreationDate");
            DropColumn("dbo.Locations", "AuthorId");
            DropColumn("dbo.Locations", "CreationDate");
            DropColumn("dbo.Events", "CreationDate");
            CreateIndex("dbo.Events", "TypeId");
            CreateIndex("dbo.Events", "LocationId");
        }
    }
}
