namespace DJobA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UType", c => c.String());
            DropColumn("dbo.AspNetUsers", "UserType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserType", c => c.String());
            DropColumn("dbo.AspNetUsers", "UType");
        }
    }
}
