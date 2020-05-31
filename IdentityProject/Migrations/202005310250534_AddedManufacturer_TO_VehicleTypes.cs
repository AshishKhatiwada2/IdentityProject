namespace IdentityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedManufacturer_TO_VehicleTypes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleTypes", "Manufacturer_Id", "dbo.Manufacturers");
            DropIndex("dbo.VehicleTypes", new[] { "Manufacturer_Id" });
            RenameColumn(table: "dbo.VehicleTypes", name: "Manufacturer_Id", newName: "ManufacturerId");
            AlterColumn("dbo.VehicleTypes", "ManufacturerId", c => c.Int(nullable: false));
            CreateIndex("dbo.VehicleTypes", "ManufacturerId");
            AddForeignKey("dbo.VehicleTypes", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleTypes", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.VehicleTypes", new[] { "ManufacturerId" });
            AlterColumn("dbo.VehicleTypes", "ManufacturerId", c => c.Int());
            RenameColumn(table: "dbo.VehicleTypes", name: "ManufacturerId", newName: "Manufacturer_Id");
            CreateIndex("dbo.VehicleTypes", "Manufacturer_Id");
            AddForeignKey("dbo.VehicleTypes", "Manufacturer_Id", "dbo.Manufacturers", "Id");
        }
    }
}
