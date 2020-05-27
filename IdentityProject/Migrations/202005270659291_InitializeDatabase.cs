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
                        AddedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Added_User_Id = c.String(maxLength: 128),
                        State_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .ForeignKey("dbo.States", t => t.State_Id)
                .Index(t => t.Added_User_Id)
                .Index(t => t.State_Id);
            
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
                "dbo.Streets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        StreetNumber = c.String(),
                        Added_User_Id = c.String(maxLength: 128),
                        City_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.Added_User_Id)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddedDate = c.DateTime(nullable: false),
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
                "dbo.Continents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Added_User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .Index(t => t.Added_User_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Added_User_Id = c.String(maxLength: 128),
                        Continent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .ForeignKey("dbo.Continents", t => t.Continent_Id)
                .Index(t => t.Added_User_Id)
                .Index(t => t.Continent_Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Zone = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Added_User_Id = c.String(maxLength: 128),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Added_User_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.EngineEmissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        EffectiveDate = c.DateTime(nullable: false),
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
                        AddedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Added_User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .Index(t => t.Added_User_Id);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Added_User_Id = c.String(maxLength: 128),
                        Manufacturer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .ForeignKey("dbo.Manufacturers", t => t.Manufacturer_Id)
                .Index(t => t.Added_User_Id)
                .Index(t => t.Manufacturer_Id);
            
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
                        AddedDate = c.DateTime(nullable: false),
                        Added_User_Id = c.String(maxLength: 128),
                        VehicleType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleType_Id)
                .Index(t => t.Added_User_Id)
                .Index(t => t.VehicleType_Id);
            
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
                        LaunchDate = c.DateTime(nullable: false),
                        Model_Year = c.Int(nullable: false),
                        Popularity = c.Single(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        User_Rating = c.Single(nullable: false),
                        Added_User_Id = c.String(maxLength: 128),
                        Rating_Id = c.Int(),
                        VehicleModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .ForeignKey("dbo.UserRatings", t => t.Rating_Id)
                .ForeignKey("dbo.VehicleModels", t => t.VehicleModel_Id)
                .Index(t => t.Added_User_Id)
                .Index(t => t.Rating_Id)
                .Index(t => t.VehicleModel_Id);
            
            CreateTable(
                "dbo.VehicleMedias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Added_Date = c.DateTime(nullable: false),
                        Path = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Added_User_Id = c.String(maxLength: 128),
                        Motorcycle_Id = c.Int(),
                        Variant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Added_User_Id)
                .ForeignKey("dbo.VehicleModels", t => t.Motorcycle_Id)
                .ForeignKey("dbo.Variants", t => t.Variant_Id)
                .Index(t => t.Added_User_Id)
                .Index(t => t.Motorcycle_Id)
                .Index(t => t.Variant_Id);
            
            CreateTable(
                "dbo.UserRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserComment = c.String(),
                        Date = c.DateTime(nullable: false),
                        ViewNumber = c.Int(nullable: false),
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
                        AddedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        city_Id = c.Int(),
                        continent_Id = c.Int(),
                        country_Id = c.Int(),
                        state_Id = c.Int(),
                        street_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.city_Id)
                .ForeignKey("dbo.Continents", t => t.continent_Id)
                .ForeignKey("dbo.Countries", t => t.country_Id)
                .ForeignKey("dbo.States", t => t.state_Id)
                .ForeignKey("dbo.Streets", t => t.street_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.city_Id)
                .Index(t => t.continent_Id)
                .Index(t => t.country_Id)
                .Index(t => t.state_Id)
                .Index(t => t.street_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        city_Id = c.Int(),
                        continent_Id = c.Int(),
                        country_Id = c.Int(),
                        state_Id = c.Int(),
                        street_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.city_Id)
                .ForeignKey("dbo.Continents", t => t.continent_Id)
                .ForeignKey("dbo.Countries", t => t.country_Id)
                .ForeignKey("dbo.States", t => t.state_Id)
                .ForeignKey("dbo.Streets", t => t.street_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.city_Id)
                .Index(t => t.continent_Id)
                .Index(t => t.country_Id)
                .Index(t => t.state_Id)
                .Index(t => t.street_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAddresses", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserAddresses", "street_Id", "dbo.Streets");
            DropForeignKey("dbo.UserAddresses", "state_Id", "dbo.States");
            DropForeignKey("dbo.UserAddresses", "country_Id", "dbo.Countries");
            DropForeignKey("dbo.UserAddresses", "continent_Id", "dbo.Continents");
            DropForeignKey("dbo.UserAddresses", "city_Id", "dbo.Cities");
            DropForeignKey("dbo.ShippingAddresses", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ShippingAddresses", "street_Id", "dbo.Streets");
            DropForeignKey("dbo.ShippingAddresses", "state_Id", "dbo.States");
            DropForeignKey("dbo.ShippingAddresses", "country_Id", "dbo.Countries");
            DropForeignKey("dbo.ShippingAddresses", "continent_Id", "dbo.Continents");
            DropForeignKey("dbo.ShippingAddresses", "city_Id", "dbo.Cities");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.VehicleTypes", "Manufacturer_Id", "dbo.Manufacturers");
            DropForeignKey("dbo.VehicleModels", "VehicleType_Id", "dbo.VehicleTypes");
            DropForeignKey("dbo.Variants", "VehicleModel_Id", "dbo.VehicleModels");
            DropForeignKey("dbo.Variants", "Rating_Id", "dbo.UserRatings");
            DropForeignKey("dbo.UserRatings", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.VehicleMedias", "Variant_Id", "dbo.Variants");
            DropForeignKey("dbo.VehicleMedias", "Motorcycle_Id", "dbo.VehicleModels");
            DropForeignKey("dbo.VehicleMedias", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Colors", "Variant_Id", "dbo.Variants");
            DropForeignKey("dbo.Variants", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.VehicleModels", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.VehicleTypes", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Manufacturers", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.EngineEmissions", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Countries", "Continent_Id", "dbo.Continents");
            DropForeignKey("dbo.States", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Cities", "State_Id", "dbo.States");
            DropForeignKey("dbo.States", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Countries", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Continents", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Colors", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Streets", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Streets", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cities", "Added_User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserAddresses", new[] { "User_Id" });
            DropIndex("dbo.UserAddresses", new[] { "street_Id" });
            DropIndex("dbo.UserAddresses", new[] { "state_Id" });
            DropIndex("dbo.UserAddresses", new[] { "country_Id" });
            DropIndex("dbo.UserAddresses", new[] { "continent_Id" });
            DropIndex("dbo.UserAddresses", new[] { "city_Id" });
            DropIndex("dbo.ShippingAddresses", new[] { "User_Id" });
            DropIndex("dbo.ShippingAddresses", new[] { "street_Id" });
            DropIndex("dbo.ShippingAddresses", new[] { "state_Id" });
            DropIndex("dbo.ShippingAddresses", new[] { "country_Id" });
            DropIndex("dbo.ShippingAddresses", new[] { "continent_Id" });
            DropIndex("dbo.ShippingAddresses", new[] { "city_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.UserRatings", new[] { "Added_User_Id" });
            DropIndex("dbo.VehicleMedias", new[] { "Variant_Id" });
            DropIndex("dbo.VehicleMedias", new[] { "Motorcycle_Id" });
            DropIndex("dbo.VehicleMedias", new[] { "Added_User_Id" });
            DropIndex("dbo.Variants", new[] { "VehicleModel_Id" });
            DropIndex("dbo.Variants", new[] { "Rating_Id" });
            DropIndex("dbo.Variants", new[] { "Added_User_Id" });
            DropIndex("dbo.VehicleModels", new[] { "VehicleType_Id" });
            DropIndex("dbo.VehicleModels", new[] { "Added_User_Id" });
            DropIndex("dbo.VehicleTypes", new[] { "Manufacturer_Id" });
            DropIndex("dbo.VehicleTypes", new[] { "Added_User_Id" });
            DropIndex("dbo.Manufacturers", new[] { "Added_User_Id" });
            DropIndex("dbo.EngineEmissions", new[] { "Added_User_Id" });
            DropIndex("dbo.States", new[] { "Country_Id" });
            DropIndex("dbo.States", new[] { "Added_User_Id" });
            DropIndex("dbo.Countries", new[] { "Continent_Id" });
            DropIndex("dbo.Countries", new[] { "Added_User_Id" });
            DropIndex("dbo.Continents", new[] { "Added_User_Id" });
            DropIndex("dbo.Colors", new[] { "Variant_Id" });
            DropIndex("dbo.Colors", new[] { "Added_User_Id" });
            DropIndex("dbo.Streets", new[] { "City_Id" });
            DropIndex("dbo.Streets", new[] { "Added_User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Cities", new[] { "State_Id" });
            DropIndex("dbo.Cities", new[] { "Added_User_Id" });
            DropTable("dbo.UserAddresses");
            DropTable("dbo.ShippingAddresses");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.UserRatings");
            DropTable("dbo.VehicleMedias");
            DropTable("dbo.Variants");
            DropTable("dbo.VehicleModels");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.EngineEmissions");
            DropTable("dbo.States");
            DropTable("dbo.Countries");
            DropTable("dbo.Continents");
            DropTable("dbo.Colors");
            DropTable("dbo.Streets");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Cities");
        }
    }
}
