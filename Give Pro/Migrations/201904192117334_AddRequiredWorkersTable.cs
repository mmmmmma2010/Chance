namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredWorkersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RequiredWorkers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequiredWorkersName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RequiredWorkers");
        }
    }
}
