using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo
            {
                ContactId =1,
                FirstName = "Durga",
                LastName = "Prasad",
                CompanyName = "Microsoft",
                EmailId = "Durga@gmail.com",
                MobileNo = 9876543321,
                Designation = "Developer"
            },

            new ContactInfo
            {
                ContactId = 2,
                FirstName = "Sateesh",
                LastName = "Kumar",
                CompanyName = "Microsoft",
                EmailId = "Sateesh@gmail.com",
                MobileNo = 9876543322,
                Designation = "Tester"


            }
        };

        public IActionResult ShowContacts()
        {
            return View(contacts);
        }

        public IActionResult GetContactById(int id)
        {
            var contact = contacts.FirstOrDefault(item => item.ContactId == id);
            return View(contact);
        }


        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo contactinfo)
        {
            contacts.Add(contactinfo);
            return RedirectToAction("ShowContacts");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ContactInfo contactObj = contacts.FirstOrDefault(item => item.ContactId == id);
            return View(contactObj);
        }

        [HttpPost]
        [ActionName("Delete")]      //  Mapping Delete Request to DeleteConfirm Action Method
        public IActionResult DeleteConfirm(int id)
        {
            ContactInfo contactObj = contacts.FirstOrDefault(item => item.ContactId == id);
            contacts.Remove(contactObj);
            return RedirectToAction("ShowContacts");
        }

        public IActionResult Search(string Designation, int ContactId)
        {

            var searchResultList = contacts.Select(item => item);

            if (Designation != null)
            {
                searchResultList = searchResultList.Where(x => x.Designation.Contains(Designation));
            }

            if (ContactId != 0)
            {
                searchResultList = searchResultList.Where(x => x.ContactId == ContactId);

            }

            return View(searchResultList.ToList());
        }
    }
}
