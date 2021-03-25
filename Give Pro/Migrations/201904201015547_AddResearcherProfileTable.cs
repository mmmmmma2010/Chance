namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResearcherProfileTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResearcherProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        NumberCard = c.String(nullable: false),
                        DateEnd = c.String(nullable: false),
                        DateBirth = c.String(nullable: false),
                        AgeID = c.Int(nullable: false),
                        NationalitiesID = c.Int(nullable: false),
                        GenderID = c.Int(nullable: false),
                        NumberPhone = c.String(nullable: false),
                        CountriesID = c.Int(nullable: false),
                        GovernoratesID = c.Int(nullable: false),
                        CitiesID = c.Int(nullable: false),
                        AddressDetails = c.String(nullable: false),
                        DrivingLicenseID = c.Int(nullable: false),
                        EducationLevelID = c.Int(nullable: false),
                        LevelEnglishID = c.Int(nullable: false),
                        LevelComputerID = c.Int(nullable: false),
                        LevelOfficeID = c.Int(nullable: false),
                        LevelArmyID = c.Int(nullable: false),
                        CompanyActivityID = c.Int(nullable: false),
                        YearsExperienceID = c.Int(nullable: false),
                        FileCV = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ages", t => t.AgeID, cascadeDelete: true)
                .ForeignKey("dbo.CompanyActivities", t => t.CompanyActivityID, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountriesID, cascadeDelete: true)
                .ForeignKey("dbo.Governorates", t => t.GovernoratesID, cascadeDelete: false)
                .ForeignKey("dbo.Cities", t => t.CitiesID, cascadeDelete: false)
                .ForeignKey("dbo.DrivingLicenses", t => t.DrivingLicenseID, cascadeDelete: true)
                .ForeignKey("dbo.EducationLevels", t => t.EducationLevelID, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.GenderID, cascadeDelete: true)
                .ForeignKey("dbo.LevelArmies", t => t.LevelArmyID, cascadeDelete: true)
                .ForeignKey("dbo.LevelComputers", t => t.LevelComputerID, cascadeDelete: true)
                .ForeignKey("dbo.LevelEnglishes", t => t.LevelEnglishID, cascadeDelete: true)
                .ForeignKey("dbo.LevelOffices", t => t.LevelOfficeID, cascadeDelete: true)
                .ForeignKey("dbo.Nationalities", t => t.NationalitiesID, cascadeDelete: true)
                .ForeignKey("dbo.YearsExperiences", t => t.YearsExperienceID, cascadeDelete: true)
                .Index(t => t.AgeID)
                .Index(t => t.NationalitiesID)
                .Index(t => t.GenderID)
                .Index(t => t.CountriesID)
                .Index(t => t.GovernoratesID)
                .Index(t => t.CitiesID)
                .Index(t => t.DrivingLicenseID)
                .Index(t => t.EducationLevelID)
                .Index(t => t.LevelEnglishID)
                .Index(t => t.LevelComputerID)
                .Index(t => t.LevelOfficeID)
                .Index(t => t.LevelArmyID)
                .Index(t => t.CompanyActivityID)
                .Index(t => t.YearsExperienceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResearcherProfiles", "YearsExperienceID", "dbo.YearsExperiences");
            DropForeignKey("dbo.ResearcherProfiles", "NationalitiesID", "dbo.Nationalities");
            DropForeignKey("dbo.ResearcherProfiles", "LevelOfficeID", "dbo.LevelOffices");
            DropForeignKey("dbo.ResearcherProfiles", "LevelEnglishID", "dbo.LevelEnglishes");
            DropForeignKey("dbo.ResearcherProfiles", "LevelComputerID", "dbo.LevelComputers");
            DropForeignKey("dbo.ResearcherProfiles", "LevelArmyID", "dbo.LevelArmies");
            DropForeignKey("dbo.ResearcherProfiles", "GenderID", "dbo.Genders");
            DropForeignKey("dbo.ResearcherProfiles", "EducationLevelID", "dbo.EducationLevels");
            DropForeignKey("dbo.ResearcherProfiles", "DrivingLicenseID", "dbo.DrivingLicenses");
            DropForeignKey("dbo.ResearcherProfiles", "CitiesID", "dbo.Cities");
            DropForeignKey("dbo.ResearcherProfiles", "GovernoratesID", "dbo.Governorates");
            DropForeignKey("dbo.ResearcherProfiles", "CountriesID", "dbo.Countries");
            DropForeignKey("dbo.ResearcherProfiles", "CompanyActivityID", "dbo.CompanyActivities");
            DropForeignKey("dbo.ResearcherProfiles", "AgeID", "dbo.Ages");
            DropIndex("dbo.ResearcherProfiles", new[] { "YearsExperienceID" });
            DropIndex("dbo.ResearcherProfiles", new[] { "CompanyActivityID" });
            DropIndex("dbo.ResearcherProfiles", new[] { "LevelArmyID" });
            DropIndex("dbo.ResearcherProfiles", new[] { "LevelOfficeID" });
            DropIndex("dbo.ResearcherProfiles", new[] { "LevelComputerID" });
            DropIndex("dbo.ResearcherProfiles", new[] { "LevelEnglishID" });
            DropIndex("dbo.ResearcherProfiles", new[] { "EducationLevelID" });
            DropIndex("dbo.ResearcherProfiles", new[] { "DrivingLicenseID" });
            DropIndex("dbo.ResearcherProfiles", new[] { "CitiesID" });
            DropIndex("dbo.ResearcherProfiles", new[] { "GovernoratesID" });
            DropIndex("dbo.ResearcherProfiles", new[] { "CountriesID" });
            DropIndex("dbo.ResearcherProfiles", new[] { "GenderID" });
            DropIndex("dbo.ResearcherProfiles", new[] { "NationalitiesID" });
            DropIndex("dbo.ResearcherProfiles", new[] { "AgeID" });
            DropTable("dbo.ResearcherProfiles");
        }
    }
}
