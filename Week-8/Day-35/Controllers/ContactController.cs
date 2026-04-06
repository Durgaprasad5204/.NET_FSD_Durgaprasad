using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        public IActionResult Details(int id)
        {
            var contactObj = _service.GetById(id);
            return View(contactObj);
        }

        public IActionResult Create()
        {
            LoadDropdowns();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _service.Add(contact);
                return RedirectToAction("Index");
            }
            else
            {
                LoadDropdowns();
                ViewBag.ErrorMessage = "Invalid Contact details.";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            LoadDropdowns();
            var contactObj = _service.GetById(id);
            return View(contactObj);
        }

        [HttpPost]
        public IActionResult Edit(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _service.Update(contact);
                return RedirectToAction("Index");
            }
            else
            {
                LoadDropdowns();
                ViewBag.ErrorMessage = "Invalid Contact details.";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contactObj = _service.GetById(id);
            return View(contactObj);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var contactObj = _service.GetById(id);

            if (contactObj != null)
            {
                _service.Delete(id);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Requested contact does not exist.";
                return View();
            }
        }

        private void LoadDropdowns()
        {
            ViewBag.Companies = new SelectList(
                _service.GetCompanies(),
                "CompanyId",
                "CompanyName");

            ViewBag.Departments = new SelectList(
                _service.GetDepartments(),
                "DepartmentId",
                "DepartmentName");
        }
    }
}