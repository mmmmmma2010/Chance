namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPublisherProfileTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PublisherProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        NumberCard = c.String(nullable: false),
                        DateEnd = c.String(nullable: false),
                        DateBirth = c.String(nullable: false),
                        NumberPhone = c.String(nullable: false),
                        CountriesID = c.Int(nullable: false),
                        GovernoratesID = c.Int(nullable: false),
                        CitiesID = c.Int(nullable: false),
                        AddressDetails = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                        CompanyActivityID = c.Int(nullable: false),
                        StaffSizeID = c.Int(nullable: false),
                        ComRegistrationNo = c.String(nullable: false),
                        LegalPaper = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        WebSite = c.String(nullable: false),
                        TimesworkID = c.Int(nullable: false),
                        GroundNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CitiesID, cascadeDelete: true)
                .ForeignKey("dbo.CompanyActivities", t => t.CompanyActivityID, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountriesID, cascadeDelete: false)
                .ForeignKey("dbo.Governorates", t => t.GovernoratesID, cascadeDelete: false)
                .ForeignKey("dbo.StaffSizes", t => t.StaffSizeID, cascadeDelete: true)
                .ForeignKey("dbo.Timesworks", t => t.TimesworkID, cascadeDelete: true)
                .Index(t => t.CountriesID)
                .Index(t => t.GovernoratesID)
                .Index(t => t.CitiesID)
                .Index(t => t.CompanyActivityID)
                .Index(t => t.StaffSizeID)
                .Index(t => t.TimesworkID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PublisherProfiles", "TimesworkID", "dbo.Timesworks");
            DropForeignKey("dbo.PublisherProfiles", "StaffSizeID", "dbo.StaffSizes");
            DropForeignKey("dbo.PublisherProfiles", "GovernoratesID", "dbo.Governorates");
            DropForeignKey("dbo.PublisherProfiles", "CountriesID", "dbo.Countries");
            DropForeignKey("dbo.PublisherProfiles", "CompanyActivityID", "dbo.CompanyActivities");
            DropForeignKey("dbo.PublisherProfiles", "CitiesID", "dbo.Cities");
            DropIndex("dbo.PublisherProfiles", new[] { "TimesworkID" });
            DropIndex("dbo.PublisherProfiles", new[] { "StaffSizeID" });
            DropIndex("dbo.PublisherProfiles", new[] { "CompanyActivityID" });
            DropIndex("dbo.PublisherProfiles", new[] { "CitiesID" });
            DropIndex("dbo.PublisherProfiles", new[] { "GovernoratesID" });
            DropIndex("dbo.PublisherProfiles", new[] { "CountriesID" });
            DropTable("dbo.PublisherProfiles");
        }
    }
}
