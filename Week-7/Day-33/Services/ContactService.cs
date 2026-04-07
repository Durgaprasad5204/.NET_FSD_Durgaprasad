using WebApplication3.Models;
using WebApplication3.Repositories;

namespace WebApplication3.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ContactInfo> GetAll()
        {
            return _repository.GetAll();
        }

        public ContactInfo GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(ContactInfo contact)
        {
            _repository.Add(contact);
        }

        public void Update(ContactInfo contact)
        {
            _repository.Update(contact);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Company> GetCompanies()
        {
            return _repository.GetCompanies();
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _repository.GetDepartments();
        }
    }
}