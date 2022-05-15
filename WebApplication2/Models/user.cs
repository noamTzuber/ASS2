using WebApplication2.Service;

namespace WebApplication2.Models
{
    public class Contact
    {

        [key]
        public string Name { get; set; } 
        public string NickName { get; set; }
        public string Server { get; set; }
        public messegesService? MessegesService { get; set; }
        public DateTime? LastDate { get; set; }
        public string? Last { get; set; }

    }
}
