namespace CST356Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modelupdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classes", "User", c => c.String());
            AddColumn("dbo.Students", "User", c => c.String());
            AddColumn("dbo.Teachers", "User", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "User");
            DropColumn("dbo.Students", "User");
            DropColumn("dbo.Classes", "User");
        }
    }
}
