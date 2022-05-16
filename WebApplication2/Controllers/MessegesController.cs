using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/contacts/{id}/[controller]")]
    public class MessegesController : Controller
    {
        private contactsService Cservice;

        public MessegesController()
        {
            Cservice = new contactsService();
        }

        [HttpGet]
        // GET: Contacts
        public ActionResult Index(string id)
        {
            if (id == null)
            { return NotFound(); }
            var contact = Cservice.get(id);
            return Json(contact.MessegesService.GetAll());
        }

        [HttpGet("{id2}")]
        public ActionResult GetMessegeById(string id, int id2)
        {
            if (id2 == null)
            { return NotFound(); }
            var contact = Cservice.get(id);
            var messege = contact.MessegesService.get(id2);
            return Json(messege);
        }

        //ADD messege to user
        [HttpPost]
        public ActionResult GetPostMessege(string id, [Bind("content")] Messege messege)
        {
            var contact = Cservice.get(id);
            contact.MessegesService.Add(messege.Content);
            return Json(Cservice);
        }

        [HttpDelete("{id2}")]
        public ActionResult DeleteMessegeById(string id, int id2)
        {
            var contact = Cservice.get(id);
            contact.MessegesService.Remove(id2);
            return Json(Cservice);
        }

        [HttpPut("{id2}")]
        public ActionResult PutContactById(string id, int id2, [Bind("content")] Messege messege)
        {
            var contact = Cservice.get(id);
            contact.MessegesService.Edit(id2, messege);
            return Json(Cservice);
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
