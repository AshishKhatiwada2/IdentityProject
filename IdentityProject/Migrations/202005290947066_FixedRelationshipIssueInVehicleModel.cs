namespace IdentityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedRelationshipIssueInVehicleModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.VehicleMedias", name: "Motorcycle_Id", newName: "VehicleModel_Id");
            RenameIndex(table: "dbo.VehicleMedias", name: "IX_Motorcycle_Id", newName: "IX_VehicleModel_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.VehicleMedias", name: "IX_VehicleModel_Id", newName: "IX_Motorcycle_Id");
            RenameColumn(table: "dbo.VehicleMedias", name: "VehicleModel_Id", newName: "Motorcycle_Id");
        }
    }
}
