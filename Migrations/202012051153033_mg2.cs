namespace HealthAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Weights", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Weights", "Date", c => c.DateTime());
        }
    }
}
