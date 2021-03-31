namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class udpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abouts", "Title", c => c.String(maxLength: 50));
            AlterColumn("dbo.Abouts", "PreTitle", c => c.String(maxLength: 50));
            AlterColumn("dbo.Abouts", "Text", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Abouts", "Text", c => c.String(maxLength: 20));
            AlterColumn("dbo.Abouts", "PreTitle", c => c.String(maxLength: 20));
            AlterColumn("dbo.Abouts", "Title", c => c.String(maxLength: 20));
        }
    }
}
