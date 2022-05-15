using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/contacts/{name}/[controller]")]
    public class MessegesController : Controller
    {
        private messegesService Mservice;
        private contactsService Cservice;

        public MessegesController()
        {
            Mservice = new messegesService();
            Cservice = new contactsService();
        }

        [HttpGet]
        // GET: Contacts
        public ActionResult Index(string name)
        {
            if (name == null)
            { return NotFound(); }
            var contact = Cservice.get(name);
            return Json(contact.MessegesService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetMessegeById(string name, int id)
        {
            if (id == null)
            { return NotFound(); }
            var contact = Cservice.get(name);
            var messege = contact.MessegesService.get(id);
            return Json(messege);
        }

        //ADD messege to user
        [HttpPost]
        public ActionResult GetPostMessege(string name, [Bind("content")] Messege messege)
        {
            var contact = Cservice.get(name);
            contact.MessegesService.Add(messege.Content);
            return Json(Cservice);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMessegeById(string name, int id)
        {
            var contact = Cservice.get(name);
            contact.MessegesService.Remove(id);
            return Json(Mservice);
        }

        [HttpPut("{id}")]
        public ActionResult PutContactById(string name, int id, [Bind("content")] Messege messege)
        {
            var contact = Cservice.get(name);
            contact.MessegesService.Edit(id, messege);
            return Json(Mservice);
        }


        // GET: Contacts/Details/5
        public ActionResult Details(int id)
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
