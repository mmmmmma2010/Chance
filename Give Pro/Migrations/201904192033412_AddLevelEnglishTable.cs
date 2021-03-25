namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLevelEnglishTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LevelEnglishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LevelEnglishName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LevelEnglishes");
        }
    }
}
