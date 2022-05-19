using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/{userID}/contacts/{id}/[controller]")]
    public class MessegesController : Controller
    {
        private usersService Uservice;

        public MessegesController()
        {
            Uservice = new usersService();
        }

        [HttpGet]
        // GET: Contacts
        public ActionResult Index(string userID, string id)
        {
            if (id == null)
            { return NotFound(); }
            var contact = Uservice.get(userID).contacts.Find(x => x.Id == id);
            return Json(contact.Messeges);
        }

        [HttpGet("{id2}")]
        public ActionResult GetMessegeById(string userID, string id, int id2)
        {
            if (id2 == null)
            { return NotFound(); }
            var contact = Uservice.get(userID).contacts.Find(x => x.Id == id);
            var messege = contact.Messeges.Find(x => x.Id == id2);
            return Json(messege);
        }

        //ADD messege to user
        [HttpPost]
        public ActionResult GetPostMessege(string userID, string id, [Bind("content")] Messege messege)
        {

            
            var contact = Uservice.get(userID).contacts.Find(x => x.Id == id);
            contact.Last = messege.Content;
            contact.LastDate = DateTime.Now;
            messege.Created = DateTime.Now;
            int nextid;
            if (contact.Messeges.Count == 0)
                nextid = 0;
            else
                nextid = contact.Messeges.Max(X => X.Id) + 1;

            messege.Id = nextid;
            messege.Sent = true;
            contact.Messeges.Add(messege);
            return Json(Uservice);
        }

        [HttpDelete("{id2}")]
        public ActionResult DeleteMessegeById(string userID, string id, int id2)
        {
            var contact = Uservice.get(userID).contacts.Find(x => x.Id == id);
             Messege c = contact.Messeges.Find(x => x.Id == id2);
            contact.Messeges.Remove(c);
            return Json(Uservice);
        }

        [HttpPut("{id2}")]
        public ActionResult PutContactById(string userID, string id, int id2, [Bind("content")] Messege messege)
        {
            var contact = Uservice.get(userID).contacts.Find(x => x.Id == id);
            contact.Messeges.Find(x => x.Id == id2).Content = messege.Content;
            contact.Messeges.Find(x => x.Id == id2).Created = DateTime.Now;

            return Json(Uservice);
        }


        // GET: Contacts/Details/5
        public ActionResult Details(int id2)
        {
            return View();
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
