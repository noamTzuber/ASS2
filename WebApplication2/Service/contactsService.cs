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

        public void Remove(string name)
        {
            Contact c = contacts.Find(x => x.Name == name);
            contacts.Remove(c);
        }

        public void Edit(string name, Contact contact)
        {
            contacts.Find(x => x.Name == name).Name = contact.Name;
            contacts.Find(x => x.Name == name).NickName = contact.NickName;
            contacts.Find(x => x.Name == name).Server = contact.Server;
        }
    }
}
