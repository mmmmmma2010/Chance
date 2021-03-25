namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobName = c.String(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        CompanyName = c.String(nullable: false),
                        CompanyActivityID = c.Int(nullable: false),
                        CountriesID = c.Int(nullable: false),
                        GovernoratesID = c.Int(nullable: false),
                        CitiesID = c.Int(nullable: false),
                        AddressDetails = c.String(nullable: false),
                        DatePublication = c.DateTime(nullable: false),
                        RequiredWorkersID = c.Int(nullable: false),
                        YearsExperienceID = c.Int(nullable: false),
                        AgeID = c.Int(nullable: false),
                        GenderID = c.Int(nullable: false),
                        DrivingLicenseID = c.Int(nullable: false),
                        EducationLevelID = c.Int(nullable: false),
                        LevelEnglishID = c.Int(nullable: false),
                        LevelComputerID = c.Int(nullable: false),
                        LevelOfficeID = c.Int(nullable: false),
                        LevelArmyID = c.Int(nullable: false),
                        OtherTerms = c.String(nullable: false),
                        MonthlySalaryID = c.Int(nullable: false),
                        WatchPrice = c.String(nullable: false),
                        AlwaysID = c.Int(nullable: false),
                        TimesworkID = c.Int(nullable: false),
                        WorkHoursID = c.Int(nullable: false),
                        WeekendID = c.Int(nullable: false),
                        AdvantagesWorkID = c.Int(nullable: false),
                        JobImage = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdvantagesWorks", t => t.AdvantagesWorkID, cascadeDelete: true)
                .ForeignKey("dbo.Ages", t => t.AgeID, cascadeDelete: true)
                .ForeignKey("dbo.Always", t => t.AlwaysID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountriesID, cascadeDelete: true)
                .ForeignKey("dbo.Governorates", t => t.GovernoratesID, cascadeDelete: false)
                .ForeignKey("dbo.Cities", t => t.CitiesID, cascadeDelete: true)
                .ForeignKey("dbo.CompanyActivities", t => t.CompanyActivityID, cascadeDelete: true)
                .ForeignKey("dbo.DrivingLicenses", t => t.DrivingLicenseID, cascadeDelete: true)
                .ForeignKey("dbo.EducationLevels", t => t.EducationLevelID, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.GenderID, cascadeDelete: true)
                .ForeignKey("dbo.LevelArmies", t => t.LevelArmyID, cascadeDelete: true)
                .ForeignKey("dbo.LevelComputers", t => t.LevelComputerID, cascadeDelete: true)
                .ForeignKey("dbo.LevelEnglishes", t => t.LevelEnglishID, cascadeDelete: true)
                .ForeignKey("dbo.LevelOffices", t => t.LevelOfficeID, cascadeDelete: true)
                .ForeignKey("dbo.MonthlySalaries", t => t.MonthlySalaryID, cascadeDelete: true)
                .ForeignKey("dbo.RequiredWorkers", t => t.RequiredWorkersID, cascadeDelete: true)
                .ForeignKey("dbo.Timesworks", t => t.TimesworkID, cascadeDelete: true)
                .ForeignKey("dbo.Weekends", t => t.WeekendID, cascadeDelete: true)
                .ForeignKey("dbo.WorkHours", t => t.WorkHoursID, cascadeDelete: true)
                .ForeignKey("dbo.YearsExperiences", t => t.YearsExperienceID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.CompanyActivityID)
                .Index(t => t.CountriesID)
                .Index(t => t.GovernoratesID)
                .Index(t => t.CitiesID)
                .Index(t => t.RequiredWorkersID)
                .Index(t => t.YearsExperienceID)
                .Index(t => t.AgeID)
                .Index(t => t.GenderID)
                .Index(t => t.DrivingLicenseID)
                .Index(t => t.EducationLevelID)
                .Index(t => t.LevelEnglishID)
                .Index(t => t.LevelComputerID)
                .Index(t => t.LevelOfficeID)
                .Index(t => t.LevelArmyID)
                .Index(t => t.MonthlySalaryID)
                .Index(t => t.AlwaysID)
                .Index(t => t.TimesworkID)
                .Index(t => t.WorkHoursID)
                .Index(t => t.WeekendID)
                .Index(t => t.AdvantagesWorkID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "YearsExperienceID", "dbo.YearsExperiences");
            DropForeignKey("dbo.Jobs", "WorkHoursID", "dbo.WorkHours");
            DropForeignKey("dbo.Jobs", "WeekendID", "dbo.Weekends");
            DropForeignKey("dbo.Jobs", "TimesworkID", "dbo.Timesworks");
            DropForeignKey("dbo.Jobs", "RequiredWorkersID", "dbo.RequiredWorkers");
            DropForeignKey("dbo.Jobs", "MonthlySalaryID", "dbo.MonthlySalaries");
            DropForeignKey("dbo.Jobs", "LevelOfficeID", "dbo.LevelOffices");
            DropForeignKey("dbo.Jobs", "LevelEnglishID", "dbo.LevelEnglishes");
            DropForeignKey("dbo.Jobs", "LevelComputerID", "dbo.LevelComputers");
            DropForeignKey("dbo.Jobs", "LevelArmyID", "dbo.LevelArmies");
            DropForeignKey("dbo.Jobs", "GenderID", "dbo.Genders");
            DropForeignKey("dbo.Jobs", "EducationLevelID", "dbo.EducationLevels");
            DropForeignKey("dbo.Jobs", "DrivingLicenseID", "dbo.DrivingLicenses");
            DropForeignKey("dbo.Jobs", "CompanyActivityID", "dbo.CompanyActivities");
            DropForeignKey("dbo.Jobs", "CitiesID", "dbo.Cities");
            DropForeignKey("dbo.Jobs", "GovernoratesID", "dbo.Governorates");
            DropForeignKey("dbo.Jobs", "CountriesID", "dbo.Countries");
            DropForeignKey("dbo.Jobs", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Jobs", "AlwaysID", "dbo.Always");
            DropForeignKey("dbo.Jobs", "AgeID", "dbo.Ages");
            DropForeignKey("dbo.Jobs", "AdvantagesWorkID", "dbo.AdvantagesWorks");
            DropIndex("dbo.Jobs", new[] { "AdvantagesWorkID" });
            DropIndex("dbo.Jobs", new[] { "WeekendID" });
            DropIndex("dbo.Jobs", new[] { "WorkHoursID" });
            DropIndex("dbo.Jobs", new[] { "TimesworkID" });
            DropIndex("dbo.Jobs", new[] { "AlwaysID" });
            DropIndex("dbo.Jobs", new[] { "MonthlySalaryID" });
            DropIndex("dbo.Jobs", new[] { "LevelArmyID" });
            DropIndex("dbo.Jobs", new[] { "LevelOfficeID" });
            DropIndex("dbo.Jobs", new[] { "LevelComputerID" });
            DropIndex("dbo.Jobs", new[] { "LevelEnglishID" });
            DropIndex("dbo.Jobs", new[] { "EducationLevelID" });
            DropIndex("dbo.Jobs", new[] { "DrivingLicenseID" });
            DropIndex("dbo.Jobs", new[] { "GenderID" });
            DropIndex("dbo.Jobs", new[] { "AgeID" });
            DropIndex("dbo.Jobs", new[] { "YearsExperienceID" });
            DropIndex("dbo.Jobs", new[] { "RequiredWorkersID" });
            DropIndex("dbo.Jobs", new[] { "CitiesID" });
            DropIndex("dbo.Jobs", new[] { "GovernoratesID" });
            DropIndex("dbo.Jobs", new[] { "CountriesID" });
            DropIndex("dbo.Jobs", new[] { "CompanyActivityID" });
            DropIndex("dbo.Jobs", new[] { "CategoryID" });
            DropTable("dbo.Jobs");
        }
    }
}
