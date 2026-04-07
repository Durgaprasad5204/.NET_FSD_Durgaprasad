using WebApplication3.Models;

namespace WebApplication3.Repositories
{
    public interface IContactRepository
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
