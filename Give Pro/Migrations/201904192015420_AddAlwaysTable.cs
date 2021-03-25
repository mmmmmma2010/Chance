namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAlwaysTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Always",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContinuityName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Always");
        }
    }
}
