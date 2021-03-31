namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateservicetable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceComponents", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceComponents", "Title");
        }
    }
}
