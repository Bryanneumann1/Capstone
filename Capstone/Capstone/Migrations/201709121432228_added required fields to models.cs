namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedrequiredfieldstomodels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Stands", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Stands", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.SuccessfulHunts", "Wind", c => c.String(nullable: false));
            AlterColumn("dbo.SuccessfulHunts", "AnimalType", c => c.String(nullable: false));
            AlterColumn("dbo.SuccessfulHunts", "WeatherConditions", c => c.String(nullable: false));
            AlterColumn("dbo.SuccessfulHunts", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SuccessfulHunts", "Description", c => c.String());
            AlterColumn("dbo.SuccessfulHunts", "WeatherConditions", c => c.String());
            AlterColumn("dbo.SuccessfulHunts", "AnimalType", c => c.String());
            AlterColumn("dbo.SuccessfulHunts", "Wind", c => c.String());
            AlterColumn("dbo.Stands", "Description", c => c.String());
            AlterColumn("dbo.Stands", "Name", c => c.String());
            AlterColumn("dbo.Customers", "Phone", c => c.String());
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "LastName", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
        }
    }
}
