using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAF
    {
        public static IRepo<Assignments,bool,int> AccessAssignments()
        {
            return new AssignmentRepos();
        }
        public static IRepo<Contents, bool, int> AccessContents()
        {
            return new ContentRepos();
        }
        public static IRepo<Course, bool, int> AccessCourses()
        {
            return new CourseRepos();
        }
        public static IRepo<Enrollments, bool, int> AccessEnrollments()
        {
            return new EnrollmentRepos();
        }
        public static IRepo<Submission, bool, int> AccessSubmissions()
        {
            return new SubmissionRepos();
        }
        public static IRepo<Teacher, bool, int> AccessTeacher()
        {
            return new TeacherProfRepos();
        }
        public static IRepo<TokenTeacher, TokenTeacher, int> AccessTeacherToken()
        {
            return new TokenTeacherRepo();
        }
        public static ITeacherAuth AccessAuthenticateTeacher()
        {
            return new TeacherProfRepos();
        }
    }
}
