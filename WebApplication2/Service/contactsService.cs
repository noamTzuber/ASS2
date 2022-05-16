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
        public Contact get(string id)
        {
            return contacts.Find(x => x.Id == id);
        }

        public void Remove(string id)
        {
            Contact c = contacts.Find(x => x.Id == id);
            contacts.Remove(c);
        }

        public void Edit(string id, Contact contact)
        {
            contacts.Find(x => x.Id == id).Id = contact.Id;
            contacts.Find(x => x.Id == id).Name = contact.Name;
            contacts.Find(x => x.Id == id).Server = contact.Server;
        }
    }
}
