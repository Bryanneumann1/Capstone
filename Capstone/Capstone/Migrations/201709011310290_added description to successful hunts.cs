namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddescriptiontosuccessfulhunts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SuccessfulHunts", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SuccessfulHunts", "Description");
        }
    }
}
