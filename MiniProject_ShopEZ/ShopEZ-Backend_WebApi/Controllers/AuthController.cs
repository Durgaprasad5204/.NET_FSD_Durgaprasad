using Microsoft.AspNetCore.Mvc;
using ShopEZ.API.DTOs;
using ShopEZ.API.Models;
using ShopEZ.API.Repositories;
using ShopEZ.API.Services;

namespace ShopEZ.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IAuthService _authService;

        public AuthController(IUserRepository userRepo, IAuthService authService)
        {
            _userRepo = userRepo;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = dto.Password,
                Role = dto.Role
            };
            await _userRepo.AddAsync(user);
            return Ok("Registered");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userRepo.GetByEmailAsync(dto.Email);
            if (user == null || user.PasswordHash != dto.Password) return Unauthorized();
            var token = _authService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}