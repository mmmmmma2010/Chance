namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResearcherProfileTable3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ResearcherProfiles", "FileCV", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ResearcherProfiles", "FileCV", c => c.String(nullable: false));
        }
    }
}
