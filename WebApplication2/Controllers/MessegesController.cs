using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessegesController : Controller
    {
        private messegesService service;

        public MessegesController()
        {
            service = new messegesService();
        }

        [HttpGet]
        // GET: Contacts
        public ActionResult Index()
        {
            return Json(service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetMessegeById(int id)
        {
            if (id == null)
            { return NotFound(); }
            var messege = service.get(id);
            return Json(messege);
        }

        [HttpPost]
        public ActionResult GetPostMessege([Bind("content")] Messege messege)
        {
            service.Add(messege);
            return Json(service);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMessegeById(int id)
        {
            service.Remove(id);
            return Json(service);
        }

        [HttpPut("{id}")]
        public ActionResult PutContactById(int id, [Bind("content")] Messege messege)
        {
            service.Edit(id, messege);
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
