namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAuth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TokenTeachers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        key = c.String(),
                        created = c.DateTime(nullable: false),
                        expiredDate = c.DateTime(nullable: false),
                        tid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Teachers", t => t.tid, cascadeDelete: false)
                .Index(t => t.tid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TokenTeachers", "tid", "dbo.Teachers");
            DropIndex("dbo.TokenTeachers", new[] { "tid" });
            DropTable("dbo.TokenTeachers");
        }
    }
}
