
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;
using WebApplication7.Repositories;

namespace ContactManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _repo;

        public ContactsController(IContactRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _repo.GetByIdAsync(id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(ContactInfo contact)
        {
            var result = await _repo.AddAsync(contact);
            return CreatedAtAction(nameof(GetById),
                new { id = result.ContactId }, result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ContactInfo contact)
        {
            if (id != contact.ContactId)
                return BadRequest();

            var updated = await _repo.UpdateAsync(contact);
            return Ok(updated);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repo.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return Ok("Deleted Successfully");
        }
    }
}