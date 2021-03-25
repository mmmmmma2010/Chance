namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStaffSizeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StaffSizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StaffSizeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StaffSizes");
        }
    }
}
