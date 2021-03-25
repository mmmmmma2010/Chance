namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLevelArmyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LevelArmies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LevelArmyName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LevelArmies");
        }
    }
}
