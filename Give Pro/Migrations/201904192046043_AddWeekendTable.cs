namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWeekendTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Weekends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WeekendName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Weekends");
        }
    }
}
