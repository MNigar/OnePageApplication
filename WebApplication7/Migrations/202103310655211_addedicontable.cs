namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedicontable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Icons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Icons = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SocialMedias", "IconId", c => c.Int(nullable: false));
            CreateIndex("dbo.SocialMedias", "IconId");
            AddForeignKey("dbo.SocialMedias", "IconId", "dbo.Icons", "Id", cascadeDelete: true);
            DropColumn("dbo.SocialMedias", "Icon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SocialMedias", "Icon", c => c.String());
            DropForeignKey("dbo.SocialMedias", "IconId", "dbo.Icons");
            DropIndex("dbo.SocialMedias", new[] { "IconId" });
            DropColumn("dbo.SocialMedias", "IconId");
            DropTable("dbo.Icons");
        }
    }
}
