namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        deadline = c.DateTime(nullable: false),
                        tid = c.Int(nullable: false),
                        cid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Courses", t => t.cid, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.tid, cascadeDelete: true)
                .Index(t => t.tid)
                .Index(t => t.cid);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        created = c.DateTime(nullable: false),
                        description = c.String(),
                        tid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Teachers", t => t.tid, cascadeDelete: false)
                .Index(t => t.tid);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        created = c.DateTime(nullable: false),
                        cid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Courses", t => t.cid, cascadeDelete: false)
                .Index(t => t.cid);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        sid = c.Int(nullable: false),
                        tid = c.Int(nullable: false),
                        cid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Courses", t => t.cid, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.sid, cascadeDelete: false)
                .ForeignKey("dbo.Teachers", t => t.tid, cascadeDelete: false)
                .Index(t => t.sid)
                .Index(t => t.tid)
                .Index(t => t.cid);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Student_Id = c.Int(nullable: false, identity: true),
                        Student_Name = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 15),
                        DOB = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Student_Id);
            
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        submitDate = c.DateTime(nullable: false),
                        content = c.String(),
                        aid = c.Int(nullable: false),
                        sid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Assignments", t => t.aid, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.sid, cascadeDelete: false)
                .Index(t => t.aid)
                .Index(t => t.sid);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        email = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignments", "tid", "dbo.Teachers");
            DropForeignKey("dbo.Assignments", "cid", "dbo.Courses");
            DropForeignKey("dbo.Courses", "tid", "dbo.Teachers");
            DropForeignKey("dbo.Enrollments", "tid", "dbo.Teachers");
            DropForeignKey("dbo.Enrollments", "sid", "dbo.Students");
            DropForeignKey("dbo.Submissions", "sid", "dbo.Students");
            DropForeignKey("dbo.Submissions", "aid", "dbo.Assignments");
            DropForeignKey("dbo.Enrollments", "cid", "dbo.Courses");
            DropForeignKey("dbo.Contents", "cid", "dbo.Courses");
            DropIndex("dbo.Submissions", new[] { "sid" });
            DropIndex("dbo.Submissions", new[] { "aid" });
            DropIndex("dbo.Enrollments", new[] { "cid" });
            DropIndex("dbo.Enrollments", new[] { "tid" });
            DropIndex("dbo.Enrollments", new[] { "sid" });
            DropIndex("dbo.Contents", new[] { "cid" });
            DropIndex("dbo.Courses", new[] { "tid" });
            DropIndex("dbo.Assignments", new[] { "cid" });
            DropIndex("dbo.Assignments", new[] { "tid" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Submissions");
            DropTable("dbo.Students");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Contents");
            DropTable("dbo.Courses");
            DropTable("dbo.Assignments");
        }
    }
}
