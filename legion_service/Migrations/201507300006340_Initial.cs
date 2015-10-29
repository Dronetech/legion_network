namespace legion_service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.sensor_data",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        sensor_name = c.String(),
                        sensor_alias = c.String(),
                        value = c.Single(nullable: false),
                        type = c.Int(nullable: false),
                        timestamp = c.DateTime(nullable: false),
                        user_networkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.user_network", t => t.user_networkId, cascadeDelete: true)
                .Index(t => t.user_networkId);
            
            CreateTable(
                "dbo.user_network",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.sensor_data", "user_networkId", "dbo.user_network");
            DropIndex("dbo.sensor_data", new[] { "user_networkId" });
            DropTable("dbo.user_network");
            DropTable("dbo.sensor_data");
        }
    }
}
