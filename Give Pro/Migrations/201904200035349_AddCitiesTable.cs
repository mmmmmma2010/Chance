namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCitiesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CitiesName = c.String(nullable: false),
                        GovernoratesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Governorates", t => t.GovernoratesID, cascadeDelete: true)
                .Index(t => t.GovernoratesID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "GovernoratesID", "dbo.Governorates");
            DropIndex("dbo.Cities", new[] { "GovernoratesID" });
            DropTable("dbo.Cities");
        }
    }
}
