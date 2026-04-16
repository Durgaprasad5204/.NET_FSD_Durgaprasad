using ContactService.Models;
using ContactService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            return Ok(_service.Add(contact));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Update(Contact contact)
        {
            return Ok(_service.Update(contact));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_service.Delete(id));
        }
    }
}