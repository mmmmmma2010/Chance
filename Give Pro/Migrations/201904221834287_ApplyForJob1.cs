namespace Give_Pro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyForJob1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplyForJobs", "Rate", c => c.Int(nullable: false));
            AddColumn("dbo.ApplyForJobs", "CV", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplyForJobs", "CV");
            DropColumn("dbo.ApplyForJobs", "Rate");
        }
    }
}
