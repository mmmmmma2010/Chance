namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEducationLevelTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EducationLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EducationLevelName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EducationLevels");
        }
    }
}
