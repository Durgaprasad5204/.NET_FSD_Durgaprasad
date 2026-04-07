using System.ComponentModel.DataAnnotations;
using WebApplication4.Models;

namespace WebApplication4.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public ICollection<Student> Students { get; set; } // Navigation Property
    }
}