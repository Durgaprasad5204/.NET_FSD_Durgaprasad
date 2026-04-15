namespace WebApplication7.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public ICollection<ContactInfo> Contacts { get; set; }
            = new List<ContactInfo>();
    }
}