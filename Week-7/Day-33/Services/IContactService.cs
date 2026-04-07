using WebApplication3.Models;

namespace WebApplication3.Services
{
    public interface IContactService
    {
        IEnumerable<ContactInfo> GetAll();
        ContactInfo GetById(int id);
        void Add(ContactInfo contact);
        void Update(ContactInfo contact);
        void Delete(int id);

        IEnumerable<Company> GetCompanies();
        IEnumerable<Department> GetDepartments();
    }
}