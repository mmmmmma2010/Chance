namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPublisherProfileTable3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PublisherProfiles", "Password", c => c.String(nullable: false));
            AddColumn("dbo.PublisherProfiles", "CompLogo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PublisherProfiles", "CompLogo");
            DropColumn("dbo.PublisherProfiles", "Password");
        }
    }
}
