namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResearcherProfileTable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ResearcherProfiles", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ResearcherProfiles", "Password");
        }
    }
}
