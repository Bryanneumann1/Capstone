namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcontrollers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        StandID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Coupon = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Stands", t => t.StandID, cascadeDelete: true)
                .Index(t => t.StandID);
            
            CreateTable(
                "dbo.Stands",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SuccessfulHunts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StandID = c.Int(nullable: false),
                        Wind = c.String(),
                        Temperature = c.Int(nullable: false),
                        TimeID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        AnimalType = c.String(),
                        NumberOfAnimals = c.Int(nullable: false),
                        WeatherConditions = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Stands", t => t.StandID, cascadeDelete: true)
                .ForeignKey("dbo.Times", t => t.TimeID, cascadeDelete: true)
                .Index(t => t.StandID)
                .Index(t => t.TimeID);
            
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SuccessfulHunts", "TimeID", "dbo.Times");
            DropForeignKey("dbo.SuccessfulHunts", "StandID", "dbo.Stands");
            DropForeignKey("dbo.Customers", "StandID", "dbo.Stands");
            DropIndex("dbo.SuccessfulHunts", new[] { "TimeID" });
            DropIndex("dbo.SuccessfulHunts", new[] { "StandID" });
            DropIndex("dbo.Customers", new[] { "StandID" });
            DropTable("dbo.Times");
            DropTable("dbo.SuccessfulHunts");
            DropTable("dbo.Stands");
            DropTable("dbo.Customers");
        }
    }
}
