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
        public User get(string id)
        {
            return users.Find(x => x.Id == id);
        }

        public List<User> GetAll()
        {
            return users;
        }


    }
}
