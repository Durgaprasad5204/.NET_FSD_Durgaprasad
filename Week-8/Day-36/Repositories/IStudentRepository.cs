using WebApplication4.Models;

namespace WebApplication4.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudentsWithCourse();
        IEnumerable<Course> GetCoursesWithStudents();
    }
}
