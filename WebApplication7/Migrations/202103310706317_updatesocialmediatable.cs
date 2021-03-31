namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesocialmediatable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SocialMedias", "Link", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SocialMedias", "Link");
        }
    }
}
