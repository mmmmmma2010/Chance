namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPublisherProfileTable5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PublisherProfiles", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PublisherProfiles", "Password", c => c.String(nullable: false));
        }
    }
}
