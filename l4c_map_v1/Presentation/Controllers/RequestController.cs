using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Threading.Tasks;
using Domain.entities;
using System.Web.Script.Serialization;
using System.Net.Mail;
using System.Net;

namespace Presentation.Controllers
{
    public class RequestController : Controller
    {
        HttpClient Client = new HttpClient();

        // GET: Request
        public ActionResult Index()
        {
            Client.BaseAddress = new Uri("http://localhost:8080/l4c_map-v1-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/request").Result;

            ViewBag.result = response.Content.ReadAsAsync<IEnumerable<RequestVM>>().Result;
            return View();
        }

        // GET: Request/Details/5
        public async Task<ActionResult> Details(int id)
        {

            Client.BaseAddress = new Uri("http://localhost:8080/l4c_map-v1-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await Client.GetAsync("rest/request/"+id);
            String res = await response.Content.ReadAsStringAsync();
            ViewBag.result = new JavaScriptSerializer().Deserialize<RequestVM>(res);



            return View();
        }

        //public async Task<ActionResult> addRequest(RequestVM request)
        //{
        //    Client.BaseAddress = new Uri("http://localhost:8080/l4c_map-v1-web/");


        //    Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    HttpResponseMessage response = await Client.PostAsJsonAsync("rest/request/", request);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index", this);

        //    }
        //    else
        //    {
        //        ViewBag.result = "erreur";
        //    }
        //    return View();
        //}

     


        // GET: Request/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            Client.BaseAddress = new Uri("http://localhost:8080/l4c_map-v1-web/");

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response1 = Client.GetAsync("rest/request/skills").Result;

            ViewBag.result = response1.Content.ReadAsAsync<IEnumerable<SkillVM>>().Result;

            return View();
        }

        // POST: Request/Create
        [HttpPost]
        public async Task<ActionResult> Create(RequestVM request)
        {
          /*  SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("khlayil0@gmail.com",
               "ilovemyself4ever");
            user u = (user)Session["user"];
            smtp.Send("khlayil0@gmail.com", u.username,
               "[request]", "your request have been comfirmed ,wait for comfirmation from responsible");

    */
            Client.BaseAddress = new Uri("http://localhost:8080/l4c_map-v1-web/");

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                // TODO: Add insert logic here
                HttpResponseMessage response = await Client.PostAsJsonAsync("rest/request/", request);
                System.Diagnostics.Debug.WriteLine("--------"+request.requiredSkills.Count+"+++++++++");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Request/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Client.BaseAddress = new Uri("http://localhost:8080/l4c_map-v1-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await Client.GetAsync("rest/request/" + id);
            String res = await response.Content.ReadAsStringAsync();
            RequestVM r = new JavaScriptSerializer().Deserialize<RequestVM>(res);

            return View(r);
        }

        // POST: Request/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, RequestVM request)
        {
            Client.BaseAddress = new Uri("http://localhost:8080/l4c_map-v1-web/");
            
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                request.idRequest = id;
                // TODO: Add insert logic here
                HttpResponseMessage response = await Client.PutAsJsonAsync("rest/request/", request);
                System.Diagnostics.Debug.WriteLine(request.cout);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Request/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Client.BaseAddress = new Uri("http://localhost:8080/l4c_map-v1-web/");
            HttpResponseMessage response = await Client.DeleteAsync("rest/request/"+ id);

            return RedirectToAction("Index");
        }

        // POST: Request/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
