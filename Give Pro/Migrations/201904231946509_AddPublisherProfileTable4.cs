namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPublisherProfileTable4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PublisherProfiles", "LegalPaper", c => c.String());
            AlterColumn("dbo.PublisherProfiles", "CompLogo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PublisherProfiles", "CompLogo", c => c.String(nullable: false));
            AlterColumn("dbo.PublisherProfiles", "LegalPaper", c => c.String(nullable: false));
        }
    }
}
