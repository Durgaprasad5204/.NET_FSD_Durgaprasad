using Dapper;
using Microsoft.Data.SqlClient;
using WebApplication4.Models;
using WebApplication4.Repositories;

namespace WebApplication4.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connStr;

        public StudentRepository(IConfiguration configuration)
        {
            _connStr = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connStr);

        }
        public IEnumerable<Student> GetStudentsWithCourse()
        {
           using( var db = GetConnection())
            {
                string sql = @"SELECT 
                               s.StudentId, s.StudentName, s.CourseId, c.CourseId, c.CourseName
                               FROM Students s
                               INNER JOIN 
                               Courses c 
                               ON s.CourseId = c.CourseId";
                return db.Query<Student, Course, Student>(
                    sql,
                    (student, course) =>
                    {
                        student.Course = course;
                        return student;


                    },
                    splitOn: "CourseId"
                    );

            }
        }

        public IEnumerable<Course> GetCoursesWithStudents()
        {
            using (var db = GetConnection())
            {
                string sql = @"SELECT
                               c.CourseId, c.CourseName,
                               s.StudentId, s.StudentName, s.CourseId
                               FROM Courses c
                               LEFT JOIN Students s
                               ON c.CourseId = s.CourseId";
                var dictObj = new Dictionary<int, Course>();
                var list = db.Query<Course, Student, Course>(
                    sql,
                    (course, student) =>
                    {
                        if (!dictObj.TryGetValue(course.CourseId, out var currentCourse))
                        {
                            currentCourse = course;
                            currentCourse.Students = new List<Student>();
                            dictObj.Add(currentCourse.CourseId, currentCourse);
                        }

                        if (student != null)
                        {
                            currentCourse.Students.Add(student);
                        }

                        return course;
                    },
                    splitOn: "StudentId"
                );

                return dictObj.Values;
            }
        }
        
    }
}