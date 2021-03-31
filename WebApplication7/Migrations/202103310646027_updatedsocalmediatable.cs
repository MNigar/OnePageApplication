namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedsocalmediatable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SocialMedias", "SettingId", c => c.Int(nullable: false));
            CreateIndex("dbo.SocialMedias", "SettingId");
            AddForeignKey("dbo.SocialMedias", "SettingId", "dbo.Settings", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SocialMedias", "SettingId", "dbo.Settings");
            DropIndex("dbo.SocialMedias", new[] { "SettingId" });
            DropColumn("dbo.SocialMedias", "SettingId");
        }
    }
}
