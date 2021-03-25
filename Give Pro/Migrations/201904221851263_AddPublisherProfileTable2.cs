namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPublisherProfileTable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PublisherProfiles", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.PublisherProfiles", "UserID");
            AddForeignKey("dbo.PublisherProfiles", "UserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PublisherProfiles", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.PublisherProfiles", new[] { "UserID" });
            DropColumn("dbo.PublisherProfiles", "UserID");
        }
    }
}
