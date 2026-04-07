using Microsoft.AspNetCore.Mvc;
using WebApplication4.Repositories;

namespace WebApplication4.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repo;

        public StudentController(IStudentRepository repo)
        {
            _repo = repo;
        }

        public IActionResult StudentsWithCourse()
        {
            var data = _repo.GetStudentsWithCourse();
            return View(data);
        }

        public IActionResult CoursesWithStudents()
        {
            var data = _repo.GetCoursesWithStudents();
            return View(data);
        }
    }
}