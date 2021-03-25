namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLevelComputerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LevelComputers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LevelComputerName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LevelComputers");
        }
    }
}
