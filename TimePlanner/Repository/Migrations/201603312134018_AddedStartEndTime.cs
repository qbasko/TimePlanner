namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStartEndTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "EndTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Events", "StartDateTime");
            DropColumn("dbo.Events", "EndDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "EndDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "StartDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Events", "EndTime");
            DropColumn("dbo.Events", "EndDate");
            DropColumn("dbo.Events", "StartTime");
            DropColumn("dbo.Events", "StartDate");
        }
    }
}
