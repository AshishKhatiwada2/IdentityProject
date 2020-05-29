namespace IdentityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationshipManagementInVehicleType1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.VehicleTypes", new[] { "manufacturer_Id" });
            CreateIndex("dbo.VehicleTypes", "Manufacturer_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.VehicleTypes", new[] { "Manufacturer_Id" });
            CreateIndex("dbo.VehicleTypes", "manufacturer_Id");
        }
    }
}
