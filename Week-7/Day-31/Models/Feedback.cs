using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Feedback
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Comments { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }
    }
}
