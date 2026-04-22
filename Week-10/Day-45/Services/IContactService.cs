using ContactManagement.Models;

namespace ContactManagement.Services
{
    public interface IContactService   // ✅ FIX
    {
        void AddContact(Contact contact);
        void UpdateContact(int id, Contact contact);
        void DeleteContact(int id);
        List<Contact> GetAllContacts();
        Contact? GetContactById(int id);
    }
}