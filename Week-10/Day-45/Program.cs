using ContactManagement.Models;
using ContactManagement.Services;

IContactService service = new ContactService();

service.AddContact(new Contact
{
    Name = "Durga",
    Email = "durga@gmail.com",
    Phone = "9999999999"
});

foreach (var contact in service.GetAllContacts())
{
    Console.WriteLine($"{contact.Id} - {contact.Name}");
}