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

        public bool UserExist(string id)
        {
            if (users.Find(x => x.Id == id) == null) return false;
            return true;
        }


        public bool UserPasswordCorrect(string id, string password)
        {
            if (users.Find(x => x.Id == id).Password == password) return true;
            return false;
        }
        

    }
}
