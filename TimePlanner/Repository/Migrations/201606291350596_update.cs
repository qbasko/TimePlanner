namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Events", "TypeId", "dbo.EventTypes");
            DropPrimaryKey("dbo.Events");
            DropPrimaryKey("dbo.Locations");
            DropPrimaryKey("dbo.EventTypes");
            AlterColumn("dbo.Events", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Events", "CreationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Locations", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Locations", "CreationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EventTypes", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.EventTypes", "CreationDate", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.Events", "Id");
            AddPrimaryKey("dbo.Locations", "Id");
            AddPrimaryKey("dbo.EventTypes", "Id");
            AddForeignKey("dbo.Events", "LocationId", "dbo.Locations", "Id");
            AddForeignKey("dbo.Events", "TypeId", "dbo.EventTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "TypeId", "dbo.EventTypes");
            DropForeignKey("dbo.Events", "LocationId", "dbo.Locations");
            DropPrimaryKey("dbo.EventTypes");
            DropPrimaryKey("dbo.Locations");
            DropPrimaryKey("dbo.Events");
            AlterColumn("dbo.EventTypes", "CreationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EventTypes", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Locations", "CreationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Locations", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Events", "CreationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.EventTypes", "Id");
            AddPrimaryKey("dbo.Locations", "Id");
            AddPrimaryKey("dbo.Events", "Id");
            AddForeignKey("dbo.Events", "TypeId", "dbo.EventTypes", "Id");
            AddForeignKey("dbo.Events", "LocationId", "dbo.Locations", "Id");
        }
    }
}
