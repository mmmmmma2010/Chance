namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdvantagesWorkTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvantagesWorks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdvantagesWorkName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdvantagesWorks");
        }
    }
}
