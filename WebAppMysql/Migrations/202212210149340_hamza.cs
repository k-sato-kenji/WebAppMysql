namespace WebAppMysql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hamza : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StdId = c.Int(nullable: false, identity: true),
                        StdName = c.String(unicode: false),
                        StdAge = c.Int(nullable: false),
                        StdAddress = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.StdId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
