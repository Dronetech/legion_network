namespace legion_service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewFormat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.sensor_data", "userGuid", c => c.String());
            AddColumn("dbo.user_network", "userGuid", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.user_network", "userGuid");
            DropColumn("dbo.sensor_data", "userGuid");
        }
    }
}
