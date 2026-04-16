using AuthService.Models;
using AuthService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            return Ok(_service.Register(user));
        }

        [HttpPost("login")]
        public IActionResult Login(User login)
        {
            var token = _service.Login(login.Email, login.Password);

            if (token == null)
                return Unauthorized();

            return Ok(new { Token = token });
        }
    }
}