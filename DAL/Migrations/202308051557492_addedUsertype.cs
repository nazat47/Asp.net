namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUsertype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "type");
        }
    }
}
