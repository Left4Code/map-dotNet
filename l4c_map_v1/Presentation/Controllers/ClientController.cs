using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("rest/client").Result;
           
          
            if (response.IsSuccessStatusCode)
            {

                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Client>>().Result;

            }
            else
            {

                ViewBag.result = "error";
            }

            
            return View();
        }

        [HttpGet]
        public ActionResult Create() {
            return View("Create"); }

        [HttpPost]

        public ActionResult Create(Client cl, HttpPostedFileBase File)
        {
            cl.Picture = File.FileName;

            cl.role = "Client";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
            client.PostAsJsonAsync<Client>("rest/client",cl).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            if (File.ContentLength > 0)
            {
                var path = System.IO.Path.Combine(Server.MapPath("~/Content/Uploads/"), File.FileName);
                File.SaveAs(path);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index"); }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response1 = client.GetAsync("rest/client/" + id).Result;
            ViewBag.result = response1.Content.ReadAsAsync<Client>().Result;
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
          
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/plain"));
            HttpResponseMessage response1 = client.DeleteAsync("rest/client/" + id).Result;

          return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response1 = client.GetAsync("rest/client/" + id).Result;
            Client c = response1.Content.ReadAsAsync<Client>().Result;

            return View(c);
        }

        [HttpPost]
        public ActionResult Edit(Client cl, FormCollection collection, HttpPostedFileBase File)
        {
           
  
            cl.Picture = File.FileName;
            HttpClient client = new HttpClient();
          
            client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
            client.PutAsJsonAsync<Client>("rest/client", cl).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            if (File.ContentLength > 0)
            {
                var path = System.IO.Path.Combine(Server.MapPath("~/Content/Uploads/"), File.FileName);
                File.SaveAs(path);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

            
        }
    }
    }


   



   

    


