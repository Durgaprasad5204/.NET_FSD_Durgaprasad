using Microsoft.AspNetCore.Mvc;
namespace WebApplication1.Controllers
{
    [Route("student")]
    public class StudentController:Controller
    {
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(string studentName, int age, string course)
        {
            TempData["StudentName"] = studentName;
            TempData["Age"] = age;
            TempData["Course"] = course;

            return RedirectToAction("Display");
        }

        [HttpGet("Display")]
        public IActionResult Display()
        { 
            ViewBag.StudentName = TempData["StudentName"];
            ViewBag.Age = TempData["Age"];
            ViewBag.Course = TempData["Course"];
            return View();
        }
    }
}
