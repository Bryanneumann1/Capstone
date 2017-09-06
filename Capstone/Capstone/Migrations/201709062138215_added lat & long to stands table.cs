namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedlatlongtostandstable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stands", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Stands", "Longitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stands", "Longitude");
            DropColumn("dbo.Stands", "Latitude");
        }
    }
}
