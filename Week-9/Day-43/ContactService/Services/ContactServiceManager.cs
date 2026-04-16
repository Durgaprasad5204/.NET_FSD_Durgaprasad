using ContactService.Models;
using ContactService.Repositories;

namespace ContactService.Services
{
    public class ContactServiceManager : IContactService
    {
        private readonly IContactRepository _repo;

        public ContactServiceManager(IContactRepository repo)
        {
            _repo = repo;
        }

        public List<Contact> GetAll() => _repo.GetAll();

        public Contact GetById(int id) => _repo.GetById(id);

        public Contact Add(Contact contact) => _repo.Add(contact);

        public Contact Update(Contact contact) => _repo.Update(contact);

        public bool Delete(int id) => _repo.Delete(id);
    }
}