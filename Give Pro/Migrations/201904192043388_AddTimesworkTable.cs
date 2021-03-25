namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimesworkTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Timesworks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimesworkName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Timesworks");
        }
    }
}
