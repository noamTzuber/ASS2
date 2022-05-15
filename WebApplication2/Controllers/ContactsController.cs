using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private contactsService service;

        public ContactsController()
        {
            service = new contactsService();
        }

        [HttpGet]
        // GET: Contacts
        public ActionResult Index()
        {
            return Json(service.GetAll());
        }

        [HttpGet("{name}")]
        public ActionResult GetContactById(string? name)
        {
            if (name == null)
            { return NotFound(); }
            var contact = service.get(name);
            return Json(contact);
        }

        [HttpPost]
        public ActionResult GetPost([Bind("name,nickName,server")] Contact contact )
        {
            contact.MessegesService = new messegesService();
            contact.MessegesService.Add("hey");
            service.Add(contact);
            return Json(service);
        }

        [HttpDelete("{name}")]
        public ActionResult DeleteContactById(string? name)
        {
            if (name == null)
            { return NotFound(); }
            service.Remove(name);
            return Json(service);
        }

        [HttpPut("{id}")]
        public ActionResult PutContactById(string id, [Bind("name,nickName,server")] Contact contact)
        {
            service.Edit(id, contact);
            return Json(service);
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
