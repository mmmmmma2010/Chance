namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGovernoratesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Governorates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GovernoratesName = c.String(nullable: false),
                        CountriesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountriesID, cascadeDelete: true)
                .Index(t => t.CountriesID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Governorates", "CountriesID", "dbo.Countries");
            DropIndex("dbo.Governorates", new[] { "CountriesID" });
            DropTable("dbo.Governorates");
        }
    }
}
