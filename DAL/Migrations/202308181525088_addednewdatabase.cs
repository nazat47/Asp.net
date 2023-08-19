namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednewdatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignments", "status", c => c.String());
            AddColumn("dbo.Submissions", "marks", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Submissions", "marks");
            DropColumn("dbo.Assignments", "status");
        }
    }
}
