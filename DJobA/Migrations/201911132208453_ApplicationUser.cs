namespace DJobA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplyForJobs", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ApplyForJobs", new[] { "UserId" });
            AddColumn("dbo.ApplyForJobs", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.ApplyForJobs", "UserId", c => c.String());
            CreateIndex("dbo.ApplyForJobs", "ApplicationUser_Id");
            AddForeignKey("dbo.ApplyForJobs", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplyForJobs", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplyForJobs", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.ApplyForJobs", "UserId", c => c.String(maxLength: 128));
            DropColumn("dbo.ApplyForJobs", "ApplicationUser_Id");
            CreateIndex("dbo.ApplyForJobs", "UserId");
            AddForeignKey("dbo.ApplyForJobs", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
