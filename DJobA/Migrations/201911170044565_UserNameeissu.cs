namespace DJobA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNameeissu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserNamee", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserNamee");
        }
    }
}
