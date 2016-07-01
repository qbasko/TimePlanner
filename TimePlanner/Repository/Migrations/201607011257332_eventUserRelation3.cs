namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventUserRelation3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventUsers", "CreationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EventUsers", "CreationDate");
        }
    }
}
