using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("feedback")]
    public class FeedbackController : Controller
    {
       
        [HttpGet("form")]
        public IActionResult FeedbackForm()
        {
            return View();
        }

        
        [HttpPost("submit")]
        public IActionResult SubmitFeedback(Feedback feedback)
        {
            if (feedback.Rating >= 4)
            {
                ViewData["Message"] = "Thank You for your positive feedback!";
            }
            else
            {
                ViewData["Message"] = "We will improve based on your feedback.";
            }

            return View("FeedbackForm");
        }
    }
}