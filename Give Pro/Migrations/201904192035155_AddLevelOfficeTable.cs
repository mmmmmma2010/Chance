namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLevelOfficeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LevelOffices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LevelOfficeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LevelOffices");
        }
    }
}
