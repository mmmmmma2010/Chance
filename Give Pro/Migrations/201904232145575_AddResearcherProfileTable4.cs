namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResearcherProfileTable4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ResearcherProfiles", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ResearcherProfiles", "Password", c => c.String(nullable: false));
        }
    }
}
