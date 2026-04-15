
using WebApplication7.Models;

namespace WebApplication7.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<ContactInfo>> GetAllAsync();
        Task<ContactInfo> GetByIdAsync(int id);
        Task<ContactInfo> AddAsync(ContactInfo contact);
        Task<ContactInfo> UpdateAsync(ContactInfo contact);
        Task<bool> DeleteAsync(int id);
    }
}