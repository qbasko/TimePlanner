namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventUserRelation31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventUsers", "EventIdCopy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EventUsers", "EventIdCopy");
        }
    }
}
