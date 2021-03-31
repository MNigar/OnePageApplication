namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPricetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Packages", "PacketPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Packages", "PriceId", c => c.Int(nullable: false));
            AddColumn("dbo.Packages", "DiskSpace", c => c.Int(nullable: false));
            AddColumn("dbo.Packages", "DomainCount", c => c.Int(nullable: false));
            AddColumn("dbo.Packages", "EmailCount", c => c.Int(nullable: false));
            CreateIndex("dbo.Packages", "PriceId");
            AddForeignKey("dbo.Packages", "PriceId", "dbo.Prices", "Id", cascadeDelete: true);
            DropColumn("dbo.Packages", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Packages", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.Packages", "PriceId", "dbo.Prices");
            DropIndex("dbo.Packages", new[] { "PriceId" });
            DropColumn("dbo.Packages", "EmailCount");
            DropColumn("dbo.Packages", "DomainCount");
            DropColumn("dbo.Packages", "DiskSpace");
            DropColumn("dbo.Packages", "PriceId");
            DropColumn("dbo.Packages", "PacketPrice");
            DropTable("dbo.Prices");
        }
    }
}
