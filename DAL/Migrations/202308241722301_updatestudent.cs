namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatestudent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
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
                .ForeignKey("dbo.Courses", t => t.cid, cascadeDelete: false)
                .ForeignKey("dbo.Teachers", t => t.tid, cascadeDelete: false)
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
                "dbo.WatchLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseTitle = c.String(nullable: false, maxLength: 20),
                        ContentTitle = c.String(nullable: false, maxLength: 20),
                        ContentStatus = c.String(nullable: false, maxLength: 20),
                        StuId = c.Int(nullable: false),
                        CntId = c.Int(nullable: false),
                        CrsId = c.Int(nullable: false),
                        MyCrsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contents", t => t.CntId, cascadeDelete: false)
                .ForeignKey("dbo.Courses", t => t.CrsId, cascadeDelete: false)
                .ForeignKey("dbo.MyCourses", t => t.MyCrsId, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.StuId, cascadeDelete: false)
                .Index(t => t.StuId)
                .Index(t => t.CntId)
                .Index(t => t.CrsId)
                .Index(t => t.MyCrsId);
            
            CreateTable(
                "dbo.MyCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 100),
                        EnrDate = c.DateTime(nullable: false),
                        Status = c.String(nullable: false, maxLength: 100),
                        StuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StuId, cascadeDelete: false)
                .Index(t => t.StuId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Student_Id = c.Int(nullable: false, identity: true),
                        Student_Name = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 15),
                        DOB = c.DateTime(nullable: false),
                        Username = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false, maxLength: 20),
                        NumOfActvCrs = c.Int(nullable: false),
                        UserType = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Student_Id);
            
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
                "dbo.Teachers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        email = c.String(),
                        password = c.String(),
                        type = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
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
                "dbo.MyAssignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Deadline = c.DateTime(nullable: false),
                        TsrId = c.Int(nullable: false),
                        CrsId = c.Int(nullable: false),
                        StuId = c.Int(nullable: false),
                        Stauts = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CrsId, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.StuId, cascadeDelete: false)
                .ForeignKey("dbo.Teachers", t => t.TsrId, cascadeDelete: false)
                .Index(t => t.TsrId)
                .Index(t => t.CrsId)
                .Index(t => t.StuId);
            
            CreateTable(
                "dbo.MySubmissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubmitDate = c.DateTime(nullable: false),
                        CourseContent = c.String(nullable: false, maxLength: 100),
                        AssId = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 100),
                        StuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MyAssignments", t => t.AssId, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.StuId, cascadeDelete: false)
                .Index(t => t.AssId)
                .Index(t => t.StuId);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        key = c.String(),
                        created = c.DateTime(nullable: false),
                        expiredDate = c.DateTime(nullable: false),
                        aid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Admins", t => t.aid, cascadeDelete: false)
                .Index(t => t.aid);
            
            CreateTable(
                "dbo.TokenStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TokenKey = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(),
                        Username = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Username)
                .Index(t => t.Username);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false, maxLength: 20),
                        UserType = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Username);
            
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
            DropForeignKey("dbo.TokenStudents", "Username", "dbo.Users");
            DropForeignKey("dbo.Tokens", "aid", "dbo.Admins");
            DropForeignKey("dbo.MyAssignments", "TsrId", "dbo.Teachers");
            DropForeignKey("dbo.MySubmissions", "StuId", "dbo.Students");
            DropForeignKey("dbo.MySubmissions", "AssId", "dbo.MyAssignments");
            DropForeignKey("dbo.MyAssignments", "StuId", "dbo.Students");
            DropForeignKey("dbo.MyAssignments", "CrsId", "dbo.Courses");
            DropForeignKey("dbo.Assignments", "tid", "dbo.Teachers");
            DropForeignKey("dbo.Assignments", "cid", "dbo.Courses");
            DropForeignKey("dbo.Courses", "tid", "dbo.Teachers");
            DropForeignKey("dbo.WatchLists", "StuId", "dbo.Students");
            DropForeignKey("dbo.WatchLists", "MyCrsId", "dbo.MyCourses");
            DropForeignKey("dbo.MyCourses", "StuId", "dbo.Students");
            DropForeignKey("dbo.Submissions", "sid", "dbo.Students");
            DropForeignKey("dbo.Submissions", "aid", "dbo.Assignments");
            DropForeignKey("dbo.Enrollments", "tid", "dbo.Teachers");
            DropForeignKey("dbo.Enrollments", "sid", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "cid", "dbo.Courses");
            DropForeignKey("dbo.WatchLists", "CrsId", "dbo.Courses");
            DropForeignKey("dbo.WatchLists", "CntId", "dbo.Contents");
            DropForeignKey("dbo.Contents", "cid", "dbo.Courses");
            DropIndex("dbo.TokenTeachers", new[] { "tid" });
            DropIndex("dbo.TokenStudents", new[] { "Username" });
            DropIndex("dbo.Tokens", new[] { "aid" });
            DropIndex("dbo.MySubmissions", new[] { "StuId" });
            DropIndex("dbo.MySubmissions", new[] { "AssId" });
            DropIndex("dbo.MyAssignments", new[] { "StuId" });
            DropIndex("dbo.MyAssignments", new[] { "CrsId" });
            DropIndex("dbo.MyAssignments", new[] { "TsrId" });
            DropIndex("dbo.Submissions", new[] { "sid" });
            DropIndex("dbo.Submissions", new[] { "aid" });
            DropIndex("dbo.Enrollments", new[] { "cid" });
            DropIndex("dbo.Enrollments", new[] { "tid" });
            DropIndex("dbo.Enrollments", new[] { "sid" });
            DropIndex("dbo.MyCourses", new[] { "StuId" });
            DropIndex("dbo.WatchLists", new[] { "MyCrsId" });
            DropIndex("dbo.WatchLists", new[] { "CrsId" });
            DropIndex("dbo.WatchLists", new[] { "CntId" });
            DropIndex("dbo.WatchLists", new[] { "StuId" });
            DropIndex("dbo.Contents", new[] { "cid" });
            DropIndex("dbo.Courses", new[] { "tid" });
            DropIndex("dbo.Assignments", new[] { "cid" });
            DropIndex("dbo.Assignments", new[] { "tid" });
            DropTable("dbo.TokenTeachers");
            DropTable("dbo.Users");
            DropTable("dbo.TokenStudents");
            DropTable("dbo.Tokens");
            DropTable("dbo.MySubmissions");
            DropTable("dbo.MyAssignments");
            DropTable("dbo.Submissions");
            DropTable("dbo.Teachers");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Students");
            DropTable("dbo.MyCourses");
            DropTable("dbo.WatchLists");
            DropTable("dbo.Contents");
            DropTable("dbo.Courses");
            DropTable("dbo.Assignments");
            DropTable("dbo.Admins");
        }
    }
}
