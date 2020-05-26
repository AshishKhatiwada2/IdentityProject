namespace IdentityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckToSeeIfPrivateFieldInModelEffectDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleModels", "Manufacturer_Id", "dbo.Manufacturers");
            DropIndex("dbo.VehicleModels", new[] { "Manufacturer_Id" });
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Added_By_Id = c.String(maxLength: 128),
                        Manufacturer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_By_Id)
                .ForeignKey("dbo.Manufacturers", t => t.Manufacturer_Id)
                .Index(t => t.Added_By_Id)
                .Index(t => t.Manufacturer_Id);
            
            AddColumn("dbo.VehicleModels", "VehicleType_Id", c => c.Int());
            CreateIndex("dbo.VehicleModels", "VehicleType_Id");
            AddForeignKey("dbo.VehicleModels", "VehicleType_Id", "dbo.VehicleTypes", "Id");
            DropColumn("dbo.VehicleModels", "Manufacturer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleModels", "Manufacturer_Id", c => c.Int());
            DropForeignKey("dbo.VehicleTypes", "Manufacturer_Id", "dbo.Manufacturers");
            DropForeignKey("dbo.VehicleModels", "VehicleType_Id", "dbo.VehicleTypes");
            DropForeignKey("dbo.VehicleTypes", "Added_By_Id", "dbo.AspNetUsers");
            DropIndex("dbo.VehicleModels", new[] { "VehicleType_Id" });
            DropIndex("dbo.VehicleTypes", new[] { "Manufacturer_Id" });
            DropIndex("dbo.VehicleTypes", new[] { "Added_By_Id" });
            DropColumn("dbo.VehicleModels", "VehicleType_Id");
            DropTable("dbo.VehicleTypes");
            CreateIndex("dbo.VehicleModels", "Manufacturer_Id");
            AddForeignKey("dbo.VehicleModels", "Manufacturer_Id", "dbo.Manufacturers", "Id");
        }
    }
}
