using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Service;
using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.SignalR;
using WebApplication2.Hubs;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api")]
    public class UsersController : Controller
    {
        private usersService Uservice;
        private readonly IHubContext<MyHub> _myHubContext;

        public UsersController(IHubContext<MyHub> myHubContext)
        {
            Uservice = new usersService();
            _myHubContext = myHubContext;
        }

        [HttpPost("add")]
        public ActionResult AddNewUser([Bind("id,name,password")] User user)
        {
            user.UserServer = "localhost:5281";
            Regex reg = new Regex(@"^(?=.*[a-zA-Z])(?=.*[0-9]).+$");

            if (Uservice.UserExist(user.Id) == true)
                return BadRequest(string.Format("The username is already exist."));

            if (user.Id.Length > 20 || user.Id.Length < 8)
                return BadRequest(string.Format("the username must be between 8 and 20 characters long"));

            if (user.Password.Length > 20 || user.Password.Length < 8)
                return BadRequest(string.Format("the password must be between 8 and 20 characters long"));

            if (reg.IsMatch(user.Password) == false)
                return BadRequest(string.Format("Your password must contain at least one letter and one number."));

            user.contacts = new contactsService();
            Uservice.Add(user);
            return Json(Uservice);
        }

        [HttpGet("users")]
        public ActionResult GetUserList()
        {
            return Json(Uservice.GetAll());
        }

        [HttpPost("user")]
        public ActionResult GetIsUser([Bind("id,password")] User user)
        {
            if (Uservice.UserExist(user.Id) == false)
                return BadRequest("The username is not exist.");            
            if (Uservice.UserPasswordCorrect(user.Id, user.Password) == false)
                return BadRequest("The password is not correct.");
            return Json(Uservice.get(user.Id));
        }

        //ADD messege to user
        [HttpPost("invitations")]
        public ActionResult GetPostInvitation([Bind("from,to,server")] Invitation invitation)
        {
            Contact contact = new Contact();
            contact.Server = invitation.Server;
            contact.Id = invitation.From;
            contact.Name = invitation.From;
            contact.MessegesService = new messegesService();
            contact.LastDate = DateTime.Now;
            contact.Last = "";
            if (invitation.Server == "localhost:5281") {
                contact.Name = Uservice.get(invitation.From).Name;
                if (Uservice.get(invitation.To) == null)
                    return BadRequest("can't add this contact");

                if (invitation.To == invitation.From)
                    return BadRequest("can't add this contact");
                if (Uservice.get(invitation.From).contacts.get(invitation.To) != null)
                    return BadRequest("can't add this contact");
            
            else
                Uservice.get(invitation.To).contacts.Add(contact);
            }
            else
                Uservice.get(invitation.To).contacts.Add(contact);
            _myHubContext.Clients.All.SendAsync("ReceiveContact", invitation.To);

            return StatusCode(201);
        }

        [HttpPost("transfer")]
        public ActionResult GetPostTransfer([Bind("from,to,content")] Transfer transfer)
        {
            var contact = Uservice.get(transfer.To).contacts.get(transfer.From);
            contact.Last = transfer.Content;
            contact.LastDate = DateTime.Now;
            contact.MessegesService.Add(transfer.Content, false);
            _myHubContext.Clients.All.SendAsync("ReceiveMessege", transfer.From, transfer.To);
            return StatusCode(201);
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

