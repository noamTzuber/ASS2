﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api")]
    public class UsersController : Controller
    {
        private usersService Uservice;

        public UsersController()
        {
            Uservice = new usersService();
        }

        [HttpPost("add")]
        public ActionResult AddNewUser([Bind("id,name,password")] User user)
        {
            user.contacts = new contactsService();
            Uservice.Add(user);
            return Json(Uservice);
        }

        [HttpGet("users")]
        public ActionResult GetUserList()
        {
            return Json(Uservice.GetAll());
        }


        //ADD messege to user
        [HttpPost("invitation")]
        public ActionResult GetPostInvitation(string from, string to, string server)
        {
            Contact contact = new Contact();
            contact.Server = server;
            contact.Id = from;
            contact.Name = Uservice.get(from).Name;
            Uservice.get(to).contacts.Add(contact);
            return Json(Uservice);
        }

        [HttpPost("transfer")]
        public ActionResult GetPostTransfer(string from, string to, string content)
        {
            Uservice.get(to).contacts.get(from).MessegesService.Add(content);
            return Json(Uservice);
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
