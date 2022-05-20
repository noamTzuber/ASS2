using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Service
{
    public class messegesService
    {
        private  List<Messege> messeges = new List<Messege>();
        
        public List<Messege> GetAll()

        {
            return messeges;
        }
        public void Add(string content, bool sent)
        {
            int nextid;
            if (messeges.Count ==0)
            {
                nextid = 0;
            }
            else { 
            nextid = messeges.Max(X => X.Id) + 1;
            }
            Messege messege = new Messege();
            messege.Content = content;
            messege.Created = DateTime.Now;
            messege.Id = nextid;
            messege.Sent = sent;
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
            messeges.Find(x => x.Id == id).Created = DateTime.Now;
        }
    }
}
