namespace IdentityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        StateId = c.Int(),
                        Added_User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.StateId)
                .Index(t => t.Added_User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Zone = c.String(),
                        AddedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        CountryId = c.Int(),
                        Added_User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId)
                .Index(t => t.Added_User_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        ContinentId = c.Int(),
                        Added_User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .ForeignKey("dbo.Continents", t => t.ContinentId)
                .Index(t => t.ContinentId)
                .Index(t => t.Added_User_Id);
            
            CreateTable(
                "dbo.Continents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        Added_User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .Index(t => t.Added_User_Id);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        ColorCode = c.String(),
                        Added_User_Id = c.String(maxLength: 128),
                        Variant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .ForeignKey("dbo.Variants", t => t.Variant_Id)
                .Index(t => t.Added_User_Id)
                .Index(t => t.Variant_Id);
            
            CreateTable(
                "dbo.EngineEmissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        AddedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        EffectiveDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        Added_User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .Index(t => t.Added_User_Id);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        ShortName = c.String(),
                        OriginCountry = c.String(),
                        BusinessNumber = c.String(),
                        AddedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        Added_User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .Index(t => t.Added_User_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ShippingAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContinentId = c.Int(),
                        CountryId = c.Int(),
                        StateId = c.Int(),
                        CityId = c.Int(),
                        StreetId = c.Int(),
                        AddedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Continents", t => t.ContinentId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.States", t => t.StateId)
                .ForeignKey("dbo.Streets", t => t.StreetId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.ContinentId)
                .Index(t => t.CountryId)
                .Index(t => t.StateId)
                .Index(t => t.CityId)
                .Index(t => t.StreetId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Streets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        CityId = c.Int(),
                        StreetNumber = c.String(),
                        Added_User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId)
                .Index(t => t.Added_User_Id);
            
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContinentId = c.Int(),
                        CountryId = c.Int(),
                        StateId = c.Int(),
                        CityId = c.Int(),
                        StreetId = c.Int(),
                        AddedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Continents", t => t.ContinentId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.States", t => t.StateId)
                .ForeignKey("dbo.Streets", t => t.StreetId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.ContinentId)
                .Index(t => t.CountryId)
                .Index(t => t.StateId)
                .Index(t => t.CityId)
                .Index(t => t.StreetId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserComment = c.String(),
                        Date = c.DateTime(precision: 7, storeType: "datetime2"),
                        ViewNumber = c.Int(nullable: false),
                        Added_User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .Index(t => t.Added_User_Id);
            
            CreateTable(
                "dbo.Variants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Ex_ShowroomPrice = c.Single(nullable: false),
                        On_Road_Price = c.Single(nullable: false),
                        Mileage = c.Single(nullable: false),
                        Engine_DisplacementCC = c.Single(nullable: false),
                        Engine_Type = c.String(),
                        Number_Of_Cylinder = c.Single(nullable: false),
                        Max_Power = c.Single(nullable: false),
                        Max_Torque = c.Single(nullable: false),
                        Front_Brake = c.String(),
                        Rear_Brake = c.String(),
                        Total_Rating = c.Single(nullable: false),
                        Fuel_Tank_Capacity = c.Single(nullable: false),
                        Body_Type = c.String(),
                        Emi_Starts = c.Single(nullable: false),
                        Insurance = c.Single(nullable: false),
                        Cooling_System = c.String(),
                        Valve_Per_Cylinder = c.String(),
                        Drive_Type = c.String(),
                        Ignition = c.String(),
                        Fuel_Supply = c.String(),
                        Clutch_Type = c.String(),
                        Engine_Start = c.String(),
                        Transmission = c.String(),
                        Gear_Box = c.String(),
                        Bore = c.String(),
                        Stroke = c.String(),
                        Emission_Type = c.String(),
                        ABS = c.String(),
                        Console = c.String(),
                        Clock = c.String(),
                        Quick_Shifter = c.String(),
                        Additional_Features = c.String(),
                        Stepup_Seat = c.String(),
                        Seat_Height_mm = c.Single(nullable: false),
                        Maximum_Height_mm = c.Single(nullable: false),
                        Maximum_Length_mm = c.Single(nullable: false),
                        Side_View_Mirror = c.String(),
                        Side_View_Mirror_Width_mm = c.Single(nullable: false),
                        Passenger_Footrest = c.String(),
                        Chassis = c.String(),
                        Front_Suspension = c.String(),
                        Rear_Suspention = c.String(),
                        Body_Graphics = c.String(),
                        Saddle_Height = c.String(),
                        Ground_Clearance = c.String(),
                        Wheelbase = c.String(),
                        Dry_Weight = c.String(),
                        Headlight = c.String(),
                        Tail_Light = c.String(),
                        Turn_Signal_Lamp = c.String(),
                        Led_Tail_Lights = c.String(),
                        Front_Tyre_Size = c.String(),
                        Rear_Tyre_Size = c.String(),
                        Tyre_Type = c.String(),
                        Front_Wheel_Size = c.String(),
                        Rear_Wheel_Size = c.String(),
                        Wheel_Type = c.String(),
                        Front_Brake_Diameter = c.String(),
                        Rear_Brake_Diameter = c.String(),
                        Kerb_Weight = c.String(),
                        Front_Track = c.String(),
                        Rear_Track = c.String(),
                        Minimum_Turning_Radius = c.String(),
                        Number_Of_Doors = c.Int(nullable: false),
                        Seat_Capacity = c.Int(nullable: false),
                        Number_Gears = c.Int(nullable: false),
                        Mileage_City = c.Single(nullable: false),
                        Mileage_Highway = c.Single(nullable: false),
                        Steering_Type = c.String(),
                        Acceleration_From_0_to_100 = c.Single(nullable: false),
                        Acceleration_From_0_to_60 = c.Single(nullable: false),
                        Max_Speed = c.Single(nullable: false),
                        LaunchDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Model_Year = c.Int(nullable: false),
                        Popularity = c.Single(nullable: false),
                        AddedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        User_Rating = c.Single(nullable: false),
                        VehicleModelId = c.Int(),
                        Added_User_Id = c.String(maxLength: 128),
                        Rating_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .ForeignKey("dbo.UserRatings", t => t.Rating_Id)
                .ForeignKey("dbo.VehicleModels", t => t.VehicleModelId)
                .Index(t => t.VehicleModelId)
                .Index(t => t.Added_User_Id)
                .Index(t => t.Rating_Id);
            
            CreateTable(
                "dbo.VehicleMedias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Added_Date = c.DateTime(precision: 7, storeType: "datetime2"),
                        Path = c.String(),
                        VehicleModelId = c.Int(),
                        VariantId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        Added_User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .ForeignKey("dbo.Variants", t => t.VariantId)
                .ForeignKey("dbo.VehicleModels", t => t.VehicleModelId)
                .Index(t => t.VehicleModelId)
                .Index(t => t.VariantId)
                .Index(t => t.Added_User_Id);
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Model_Name = c.String(),
                        Popularity = c.Single(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        User_Rating = c.Single(nullable: false),
                        AddedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        VehicleTypeId = c.Int(),
                        Added_User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeId)
                .Index(t => t.VehicleTypeId)
                .Index(t => t.Added_User_Id);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        ManufacturerId = c.Int(),
                        Added_User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId)
                .Index(t => t.ManufacturerId)
                .Index(t => t.Added_User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Variants", "VehicleModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.Variants", "Rating_Id", "dbo.UserRatings");
            DropForeignKey("dbo.VehicleMedias", "VehicleModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.VehicleModels", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.VehicleTypes", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.VehicleTypes", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.VehicleModels", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.VehicleMedias", "VariantId", "dbo.Variants");
            DropForeignKey("dbo.VehicleMedias", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Colors", "Variant_Id", "dbo.Variants");
            DropForeignKey("dbo.Variants", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserRatings", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserAddresses", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserAddresses", "StreetId", "dbo.Streets");
            DropForeignKey("dbo.UserAddresses", "StateId", "dbo.States");
            DropForeignKey("dbo.UserAddresses", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.UserAddresses", "ContinentId", "dbo.Continents");
            DropForeignKey("dbo.UserAddresses", "CityId", "dbo.Cities");
            DropForeignKey("dbo.ShippingAddresses", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ShippingAddresses", "StreetId", "dbo.Streets");
            DropForeignKey("dbo.Streets", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Streets", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ShippingAddresses", "StateId", "dbo.States");
            DropForeignKey("dbo.ShippingAddresses", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.ShippingAddresses", "ContinentId", "dbo.Continents");
            DropForeignKey("dbo.ShippingAddresses", "CityId", "dbo.Cities");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Manufacturers", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.EngineEmissions", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Colors", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cities", "StateId", "dbo.States");
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Countries", "ContinentId", "dbo.Continents");
            DropForeignKey("dbo.Continents", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Countries", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.States", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cities", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.VehicleTypes", new[] { "Added_User_Id" });
            DropIndex("dbo.VehicleTypes", new[] { "ManufacturerId" });
            DropIndex("dbo.VehicleModels", new[] { "Added_User_Id" });
            DropIndex("dbo.VehicleModels", new[] { "VehicleTypeId" });
            DropIndex("dbo.VehicleMedias", new[] { "Added_User_Id" });
            DropIndex("dbo.VehicleMedias", new[] { "VariantId" });
            DropIndex("dbo.VehicleMedias", new[] { "VehicleModelId" });
            DropIndex("dbo.Variants", new[] { "Rating_Id" });
            DropIndex("dbo.Variants", new[] { "Added_User_Id" });
            DropIndex("dbo.Variants", new[] { "VehicleModelId" });
            DropIndex("dbo.UserRatings", new[] { "Added_User_Id" });
            DropIndex("dbo.UserAddresses", new[] { "User_Id" });
            DropIndex("dbo.UserAddresses", new[] { "StreetId" });
            DropIndex("dbo.UserAddresses", new[] { "CityId" });
            DropIndex("dbo.UserAddresses", new[] { "StateId" });
            DropIndex("dbo.UserAddresses", new[] { "CountryId" });
            DropIndex("dbo.UserAddresses", new[] { "ContinentId" });
            DropIndex("dbo.Streets", new[] { "Added_User_Id" });
            DropIndex("dbo.Streets", new[] { "CityId" });
            DropIndex("dbo.ShippingAddresses", new[] { "User_Id" });
            DropIndex("dbo.ShippingAddresses", new[] { "StreetId" });
            DropIndex("dbo.ShippingAddresses", new[] { "CityId" });
            DropIndex("dbo.ShippingAddresses", new[] { "StateId" });
            DropIndex("dbo.ShippingAddresses", new[] { "CountryId" });
            DropIndex("dbo.ShippingAddresses", new[] { "ContinentId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Manufacturers", new[] { "Added_User_Id" });
            DropIndex("dbo.EngineEmissions", new[] { "Added_User_Id" });
            DropIndex("dbo.Colors", new[] { "Variant_Id" });
            DropIndex("dbo.Colors", new[] { "Added_User_Id" });
            DropIndex("dbo.Continents", new[] { "Added_User_Id" });
            DropIndex("dbo.Countries", new[] { "Added_User_Id" });
            DropIndex("dbo.Countries", new[] { "ContinentId" });
            DropIndex("dbo.States", new[] { "Added_User_Id" });
            DropIndex("dbo.States", new[] { "CountryId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Cities", new[] { "Added_User_Id" });
            DropIndex("dbo.Cities", new[] { "StateId" });
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.VehicleModels");
            DropTable("dbo.VehicleMedias");
            DropTable("dbo.Variants");
            DropTable("dbo.UserRatings");
            DropTable("dbo.UserAddresses");
            DropTable("dbo.Streets");
            DropTable("dbo.ShippingAddresses");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.EngineEmissions");
            DropTable("dbo.Colors");
            DropTable("dbo.Continents");
            DropTable("dbo.Countries");
            DropTable("dbo.States");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Cities");
        }
    }
}
