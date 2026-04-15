using Microsoft.EntityFrameworkCore;
using WebApplication7.Models;

namespace WebApplication7.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _context;

        public ContactRepository(ContactDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContactInfo>> GetAllAsync()
        {
            return await _context.Contacts
                .Include(c => c.CompanyId)
                .Include(c => c.Department)
                .ToListAsync();
        }

        public async Task<ContactInfo> GetByIdAsync(int id)
        {
            return await _context.Contacts
                .Include(c => c.Company)
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.ContactId == id);
        }

        public async Task<ContactInfo> AddAsync(ContactInfo contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<ContactInfo> UpdateAsync(ContactInfo contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
                return false;

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}