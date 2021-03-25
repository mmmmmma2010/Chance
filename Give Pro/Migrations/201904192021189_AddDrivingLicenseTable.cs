namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDrivingLicenseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DrivingLicenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DrivingLicenseName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DrivingLicenses");
        }
    }
}
