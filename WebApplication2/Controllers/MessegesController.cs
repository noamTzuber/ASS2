using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Service;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Specialized;
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
            var contact = Uservice.get(userID).contacts.get(id);
            return Json(contact.MessegesService.GetAll());
        }

        [HttpGet("{id2}")]
        public ActionResult GetMessegeById(string userID, string id, int id2)
        {
            if (id2 == null)
            { return NotFound(); }
            var contact = Uservice.get(userID).contacts.get(id);
            var messege = contact.MessegesService.get(id2);
            return Json(messege);
        }

        //ADD messege to user
        [HttpPost]
        public async Task<ActionResult> GetPostMessegeAsync(string userID, string id, [Bind("content")] Messege messege)
        {
            var contact = Uservice.get(userID).contacts.get(id);
            var server = contact.Server;
            contact.Last = messege.Content;
            contact.LastDate = DateTime.Now;
            contact.MessegesService.Add(messege.Content, true);
            // HttpClient client = new HttpClient();
            //var values = new Dictionary<string, string>
            //{
            // { "from", userID },
            //  { "to", id },
            //  { "content", messege.Content }
            //  };

            //  var content = new FormUrlEncodedContent(values);

            //  var response = await client.PostAsync("http://" + server + "/api/transfer", content);

            //   var responseString = await response.Content.ReadAsStringAsync();
            // var wb = new WebClient();
            //  var data = new NameValueCollection();
            //  string url = "http://" + server + "/api/transfer";
            //  data["from"] = userID;
            // data["to"] = id;
            //  data["content"] = messege.Content;

            //   var response = wb.UploadValues(url, "POST", data);
            //var url = "http://" + server + "/api/transfer";

            //var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            //httpRequest.Method = "POST";

            //httpRequest.Accept = "application/json";
            // httpRequest.ContentType = "application/json";

             
            //using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            //{
            //    streamWriter.Write(data);
            //}

            //var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            //{
            //  var result = streamReader.ReadToEnd();
            //}

            //  Console.WriteLine(httpResponse.StatusCode);

            var transfer = new Transfer();
            transfer.Content = messege.Content;
            transfer.From = userID;
            transfer.To = id;
            var json = JsonConvert.SerializeObject(transfer);
            var d = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://" + server + "/api/transfer";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, d);

            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
            return Json(Uservice);
        }

        [HttpDelete("{id2}")]
        public ActionResult DeleteMessegeById(string userID, string id, int id2)
        {
            var contact = Uservice.get(userID).contacts.get(id);
            contact.MessegesService.Remove(id2);
            return Json(Uservice);
        }

        [HttpPut("{id2}")]
        public ActionResult PutContactById(string userID, string id, int id2, [Bind("content")] Messege messege)
        {
            var contact = Uservice.get(userID).contacts.get(id);
            contact.MessegesService.Edit(id2, messege);
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
