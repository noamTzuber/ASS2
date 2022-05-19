using WebApplication2.Service;

namespace WebApplication2.Models
{
    public class Contact
    {

        [key]
        public string Id { get; set; } 
        public string Name { get; set; }
        public string Server { get; set; }
        public List<Messege>? Messeges { get; set; }
        public DateTime? LastDate { get; set; }
        public string? Last { get; set; }

    }
}
