namespace legion_service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_sensor_Data : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.sensor_data", "temperature", c => c.Single(nullable: false));
            AddColumn("dbo.sensor_data", "humidity", c => c.Int(nullable: false));
            AddColumn("dbo.sensor_data", "voltage", c => c.Int(nullable: false));
            DropColumn("dbo.sensor_data", "value");
            DropColumn("dbo.sensor_data", "type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.sensor_data", "type", c => c.Int(nullable: false));
            AddColumn("dbo.sensor_data", "value", c => c.Single(nullable: false));
            DropColumn("dbo.sensor_data", "voltage");
            DropColumn("dbo.sensor_data", "humidity");
            DropColumn("dbo.sensor_data", "temperature");
        }
    }
}
