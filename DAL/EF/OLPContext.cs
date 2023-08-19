using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class OLPContext:DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Contents> Contents { get; set; }
        public DbSet<Enrollments> Enrollments { get; set; }
        public DbSet<Assignments> Assignments { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<TokenTeacher> TokenTeachers { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

    }
}
