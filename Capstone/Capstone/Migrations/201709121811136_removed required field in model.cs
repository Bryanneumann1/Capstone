namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedrequiredfieldinmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stands", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stands", "Name", c => c.String(nullable: false));
        }
    }
}
