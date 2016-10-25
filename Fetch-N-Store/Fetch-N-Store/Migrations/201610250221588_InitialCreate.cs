namespace Fetch_N_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Responses",
                c => new
                    {
                        ResponseId = c.Int(nullable: false, identity: true),
                        StatusCode = c.Int(nullable: false),
                        URL = c.String(nullable: false),
                        ResponseTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ResponseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Responses");
        }
    }
}
