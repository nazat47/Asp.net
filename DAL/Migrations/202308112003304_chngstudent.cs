namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chngstudent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Submissions", "sid", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "sid", "dbo.Students");
            DropPrimaryKey("dbo.Students");
            AddColumn("dbo.Students", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Students", "Gender", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Students", "Student_Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Students", "Email", c => c.String(nullable: false, maxLength: 100));
            AddPrimaryKey("dbo.Students", "Id");
            AddForeignKey("dbo.Submissions", "sid", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Enrollments", "sid", "dbo.Students", "Id", cascadeDelete: true);
            DropColumn("dbo.Students", "Student_Id");
            DropColumn("dbo.Students", "DOB");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.Students", "Student_Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Enrollments", "sid", "dbo.Students");
            DropForeignKey("dbo.Submissions", "sid", "dbo.Students");
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "Email", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Students", "Student_Name", c => c.String(nullable: false, maxLength: 15));
            DropColumn("dbo.Students", "Gender");
            DropColumn("dbo.Students", "Id");
            AddPrimaryKey("dbo.Students", "Student_Id");
            AddForeignKey("dbo.Enrollments", "sid", "dbo.Students", "Student_Id", cascadeDelete: true);
            AddForeignKey("dbo.Submissions", "sid", "dbo.Students", "Student_Id", cascadeDelete: true);
        }
    }
}
