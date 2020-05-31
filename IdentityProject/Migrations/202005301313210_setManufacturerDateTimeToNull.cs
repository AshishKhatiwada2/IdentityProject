namespace IdentityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setManufacturerDateTimeToNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Manufacturers", "AddedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Manufacturers", "AddedDate", c => c.DateTime(nullable: false));
        }
    }
}
