namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResearcherProfileTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ResearcherProfiles", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.ResearcherProfiles", "UserID");
            AddForeignKey("dbo.ResearcherProfiles", "UserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResearcherProfiles", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.ResearcherProfiles", new[] { "UserID" });
            DropColumn("dbo.ResearcherProfiles", "UserID");
        }
    }
}
