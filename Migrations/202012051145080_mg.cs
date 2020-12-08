namespace HealthAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BloodSugars", "Date", c => c.DateTime());
            AlterColumn("dbo.Pressures", "Date", c => c.DateTime());
            AlterColumn("dbo.Pulses", "Date", c => c.DateTime());
            AlterColumn("dbo.Weights", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Weights", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Pulses", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Pressures", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BloodSugars", "Date", c => c.DateTime(nullable: false));
        }
    }
}
