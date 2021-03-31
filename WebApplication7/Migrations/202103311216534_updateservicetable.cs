namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateservicetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "Title", c => c.String());
            AddColumn("dbo.Services", "SubTitle", c => c.String());
            DropColumn("dbo.Services", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "Name", c => c.String());
            DropColumn("dbo.Services", "SubTitle");
            DropColumn("dbo.Services", "Title");
        }
    }
}
