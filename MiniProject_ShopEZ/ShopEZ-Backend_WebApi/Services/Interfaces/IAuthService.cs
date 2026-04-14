using ShopEZ.API.Models;

namespace ShopEZ.API.Services
{
    public interface IAuthService
    {
        string GenerateToken(User user);
    }
}