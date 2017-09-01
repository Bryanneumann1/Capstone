namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedtimetable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SuccessfulHunts", "TimeID", "dbo.Times");
            DropIndex("dbo.SuccessfulHunts", new[] { "TimeID" });
            DropColumn("dbo.SuccessfulHunts", "TimeID");
            DropTable("dbo.Times");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.SuccessfulHunts", "TimeID", c => c.Int(nullable: false));
            CreateIndex("dbo.SuccessfulHunts", "TimeID");
            AddForeignKey("dbo.SuccessfulHunts", "TimeID", "dbo.Times", "ID", cascadeDelete: true);
        }
    }
}
