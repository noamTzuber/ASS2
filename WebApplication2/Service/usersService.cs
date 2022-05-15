using WebApplication2.Models;

namespace WebApplication2.Service
{
    public class usersService
    {
        private static List<User> users = new List<User>();
        
        public void Add(User user)
        {
            users.Add(user);
        }
        public User get(string name)
        {
            return users.Find(x => x.Name == name);
        }

       
    }
}
