namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddescriptiontostand : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stands", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stands", "Description");
        }
    }
}
