namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddYearsExperienceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.YearsExperiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YearsExperienceName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.YearsExperiences");
        }
    }
}
