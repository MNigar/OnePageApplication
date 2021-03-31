namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPackagetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Packages", "Support", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Packages", "Support");
        }
    }
}
