using System;
using System.Collections.Generic;
using System.Linq;

using ContactManagement.Models;

namespace ContactManagement.Services
{
    public class ContactService : IContactService
    {
        private readonly List<Contact> _contacts = new();
        private int _nextId = 1;

        public void AddContact(Contact contact)
        {
            ValidateContact(contact);

            contact.Id = _nextId++;
            _contacts.Add(contact);
        }

        public void UpdateContact(int id, Contact updatedContact)
        {
            ValidateContact(updatedContact);

            Contact existing = FindContactById(id);

            existing.Name = updatedContact.Name;
            existing.Email = updatedContact.Email;
            existing.Phone = updatedContact.Phone;
        }

        public void DeleteContact(int id)
        {
            Contact contact = FindContactById(id);
            _contacts.Remove(contact);
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public Contact? GetContactById(int id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }

        // 🔹 Helper Methods (removes duplication)
        private Contact FindContactById(int id)
        {
            Contact? contact = _contacts.FirstOrDefault(c => c.Id == id);

            if (contact == null)
                throw new ArgumentException("Contact not found");

            return contact;
        }

        private static void ValidateContact(Contact contact)
        {
            if (string.IsNullOrWhiteSpace(contact.Name))
                throw new ArgumentException("Name is required");

            if (string.IsNullOrWhiteSpace(contact.Email))
                throw new ArgumentException("Email is required");

            if (string.IsNullOrWhiteSpace(contact.Phone))
                throw new ArgumentException("Phone is required");
        }
    }
}