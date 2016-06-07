namespace EveOnlineMissioningApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        credential_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.PasswordCredentials", t => t.credential_id)
                .Index(t => t.credential_id);
            
            CreateTable(
                "dbo.PasswordCredentials",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        hash = c.String(),
                        salt_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Salts", t => t.salt_id)
                .Index(t => t.salt_id);
            
            CreateTable(
                "dbo.Salts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.MissionCaptures",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        startTime = c.DateTime(nullable: false),
                        endTime = c.DateTime(nullable: false),
                        title = c.String(),
                        income = c.Single(nullable: false),
                        expenses = c.Single(nullable: false),
                        profit = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "credential_id", "dbo.PasswordCredentials");
            DropForeignKey("dbo.PasswordCredentials", "salt_id", "dbo.Salts");
            DropIndex("dbo.PasswordCredentials", new[] { "salt_id" });
            DropIndex("dbo.Accounts", new[] { "credential_id" });
            DropTable("dbo.MissionCaptures");
            DropTable("dbo.Salts");
            DropTable("dbo.PasswordCredentials");
            DropTable("dbo.Accounts");
        }
    }
}
