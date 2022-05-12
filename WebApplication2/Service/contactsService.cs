using WebApplication2.Models;

namespace WebApplication2.Service
{
    public class contactsService
    {
        private static List<Contact> contacts = new List<Contact>();
        public List<Contact> GetAll()
        {
            return contacts;
        }
        public void Add(Contact contact)
        {
            contacts.Add(contact);
        }
        public Contact get(string name)
        {
            return contacts.Find(x => x.Name == name);
        }
    }
}
