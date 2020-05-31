namespace IdentityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedErrorDueToDateTimeIssueByAddingNullAndDateTime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cities", "AddedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.States", "AddedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Countries", "AddedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Continents", "AddedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Colors", "AddedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.EngineEmissions", "AddedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.EngineEmissions", "EffectiveDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Manufacturers", "AddedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.ShippingAddresses", "AddedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Streets", "AddedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.UserAddresses", "AddedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.UserRatings", "Date", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Variants", "LaunchDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Variants", "AddedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.VehicleMedias", "Added_Date", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.VehicleModels", "AddedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleModels", "AddedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.VehicleMedias", "Added_Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Variants", "AddedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Variants", "LaunchDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UserRatings", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UserAddresses", "AddedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Streets", "AddedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ShippingAddresses", "AddedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Manufacturers", "AddedDate", c => c.DateTime());
            AlterColumn("dbo.EngineEmissions", "EffectiveDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EngineEmissions", "AddedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Colors", "AddedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Continents", "AddedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Countries", "AddedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.States", "AddedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Cities", "AddedDate", c => c.DateTime(nullable: false));
        }
    }
}
