using AuthService.Models;

namespace AuthService.Repositories
{
    public interface IUserRepository
    {
        User Register(User user);
        User Validate(string email, string password);
    }
}