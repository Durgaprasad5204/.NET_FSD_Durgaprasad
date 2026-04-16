using AuthService.Models;

namespace AuthService.Services
{
    public interface IAuthService
    {
        string Login(string email, string password);
        User Register(User user);
    }
}