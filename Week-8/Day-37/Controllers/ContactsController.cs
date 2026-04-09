using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo
            {
                ContactId = 1,
                FirstName = "Durga",
                LastName = "Prasad",
                EmailId = "durga@gmail.com",
                MobileNo = 9876543210,
                Designation = "Developer",
                CompanyId = 101,
                DepartmentId = 1
            },
            new ContactInfo
            {
                ContactId = 2,
                FirstName = "Ravi",
                LastName = "Kumar",
                EmailId = "Ravi@gmail.com",
                MobileNo = 9876543211,
                Designation = "Tester",
                CompanyId = 101,
                DepartmentId = 2
            },
            new ContactInfo
            {
                ContactId = 3,
                FirstName = "Srinivas",
                LastName = "Rao",
                EmailId = "srinivas@gmail.com",
                MobileNo = 9876543221,
                Designation = "Hr",
                CompanyId = 101,
                DepartmentId = 3
            }

        };

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = contacts.Find(x => x.ContactId == id);

            if (contact == null)
                return NotFound("Contact not found");

            return Ok(contact);
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo contact)
        {
            contact.ContactId = contacts.Count > 0
                ? contacts.Max(x => x.ContactId) + 1
                : 1;

            contacts.Add(contact);

            return CreatedAtAction(nameof(GetContactById),
                new { id = contact.ContactId }, contact);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, ContactInfo contact)
        {
            var oldContact = contacts.Find(x => x.ContactId == id);

            if (oldContact == null)
                return NotFound("Contact not found");

            oldContact.FirstName = contact.FirstName;
            oldContact.LastName = contact.LastName;
            oldContact.EmailId = contact.EmailId;
            oldContact.MobileNo = contact.MobileNo;
            oldContact.Designation = contact.Designation;
            oldContact.CompanyId = contact.CompanyId;
            oldContact.DepartmentId = contact.DepartmentId;

            return Ok("Contact updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contact = contacts.Find(x => x.ContactId == id);

            if (contact == null)
                return NotFound("Contact not found");

            contacts.Remove(contact);

            return Ok("Contact deleted successfully");
        }
    }
}
        
