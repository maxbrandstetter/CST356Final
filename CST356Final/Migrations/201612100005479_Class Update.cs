namespace CST356Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classes", "Subject", c => c.String(nullable: false, maxLength: 64));
            DropColumn("dbo.Classes", "EmailAddress");
            DropColumn("dbo.Classes", "YearsExperience");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Classes", "YearsExperience", c => c.String(nullable: false));
            AddColumn("dbo.Classes", "EmailAddress", c => c.String(nullable: false, maxLength: 64));
            DropColumn("dbo.Classes", "Subject");
        }
    }
}
