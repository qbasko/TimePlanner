namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventUserRelation32 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.EventUsers", "EventIdCopy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventUsers", "EventIdCopy", c => c.String());
        }
    }
}
