namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedkillscontroller : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StandID = c.Int(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Stands", t => t.StandID, cascadeDelete: true)
                .Index(t => t.StandID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kills", "StandID", "dbo.Stands");
            DropIndex("dbo.Kills", new[] { "StandID" });
            DropTable("dbo.Kills");
        }
    }
}
