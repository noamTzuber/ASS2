using WebApplication2.Service;

namespace WebApplication2.Models
{
    public class User
    {

        [key]
        public string Id { get; set; } 
        public string Name { get; set; }
        public string Passward { get; set; }
        public contactsService contacts { get; set; }
        public string? UserServer { get; set; }
    }
}
