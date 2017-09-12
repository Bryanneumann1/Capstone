namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfinalpricecolumntocustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "FinalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "FinalPrice");
        }
    }
}
