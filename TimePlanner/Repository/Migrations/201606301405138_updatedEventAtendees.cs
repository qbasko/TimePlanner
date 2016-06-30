namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedEventAtendees : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "UserId", newName: "AuthorId");
            RenameIndex(table: "dbo.Events", name: "IX_UserId", newName: "IX_AuthorId");
            AddColumn("dbo.AspNetUsers", "Event_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "Event_Id");
            AddForeignKey("dbo.AspNetUsers", "Event_Id", "dbo.Events", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Event_Id", "dbo.Events");
            DropIndex("dbo.AspNetUsers", new[] { "Event_Id" });
            DropColumn("dbo.AspNetUsers", "Event_Id");
            RenameIndex(table: "dbo.Events", name: "IX_AuthorId", newName: "IX_UserId");
            RenameColumn(table: "dbo.Events", name: "AuthorId", newName: "UserId");
        }
    }
}
