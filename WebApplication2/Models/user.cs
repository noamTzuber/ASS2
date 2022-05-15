using WebApplication2.Service;

namespace WebApplication2.Models
{
    public class User
    {

        [key]
        public string Name { get; set; } 
        public string NickName { get; set; }
        public string Passward { get; set; }
        public contactsService contacts { get; set; }
        public string? UserServer { get; set; }
    }
}
