using WebApplication2.Models;

namespace WebApplication2.Service
{
    public class messegesService
    {
        private static List<Messege> messeges = new List<Messege>();
        public List<Messege> GetAll()
        {
            return messeges;
        }
        public void Add(Messege messege)
        {
            messeges.Add(messege);
        }
        public Messege get(int id)
        {
            return messeges.Find(x => x.Id == id);
        }

        public void Remove(int id)
        {
            Messege c = messeges.Find(x => x.Id == id);
            messeges.Remove(c);
        }

        public void Edit(int id, Messege messege)
        {
            messeges.Find(x => x.Id == id).Content = messege.Content;
            messeges.Find(x => x.Id == id).Created = messege.Created;
        }
    }
}
