namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerCode = c.Int(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GameRent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                        RentalDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.GameId)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .Index(t => t.CustomerId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        GameTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameType", t => t.GameTypeId)
                .Index(t => t.GameTypeId);
            
            CreateTable(
                "dbo.GameType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameRent", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.GameRent", "GameId", "dbo.Game");
            DropForeignKey("dbo.Game", "GameTypeId", "dbo.GameType");
            DropIndex("dbo.Game", new[] { "GameTypeId" });
            DropIndex("dbo.GameRent", new[] { "GameId" });
            DropIndex("dbo.GameRent", new[] { "CustomerId" });
            DropTable("dbo.GameType");
            DropTable("dbo.Game");
            DropTable("dbo.GameRent");
            DropTable("dbo.Customer");
        }
    }
}
