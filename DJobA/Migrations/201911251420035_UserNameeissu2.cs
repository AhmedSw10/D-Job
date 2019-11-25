namespace DJobA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNameeissu2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "UserNamee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserNamee", c => c.String());
        }
    }
}
