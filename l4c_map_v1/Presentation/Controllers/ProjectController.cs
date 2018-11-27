using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("rest/project").Result;


            if (response.IsSuccessStatusCode)
            {
                

               ViewBag.result= response.Content.ReadAsAsync<IEnumerable<Projet>>().Result;
           
            }
            else
            {

                ViewBag.result = "error";
            }
            return View();
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("rest/client").Result;
            var clients = response.Content.ReadAsAsync<IEnumerable<Client>>().Result;
            ViewBag.MyClients = new SelectList(clients, "id", "name");
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(ProjetMv pr,FormCollection collection, HttpPostedFileBase File)
        {
            pr.picture = File.FileName;

            HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
             
                client.PostAsJsonAsync<ProjetMv>("rest/project/"+pr.idClient, pr).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            if (File.ContentLength > 0)
            {
                var path = System.IO.Path.Combine(Server.MapPath("~/Content/Uploads/"), File.FileName);
                File.SaveAs(path);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

                
            
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response1 = client.GetAsync("rest/project/"+id).Result;
            Projet pr = response1.Content.ReadAsAsync<Projet>().Result;


            return View(pr);
        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(Projet pr ,FormCollection collection, HttpPostedFileBase File)
        {
            pr.picture = File.FileName;
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
            client.PutAsJsonAsync<Projet>("rest/project", pr).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            if (File.ContentLength > 0)
            {
                var path = System.IO.Path.Combine(Server.MapPath("~/Content/Uploads/"), File.FileName);
                File.SaveAs(path);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response1 = client.GetAsync("rest/project/" + id).Result;
            ViewBag.result= response1.Content.ReadAsAsync<Projet>().Result;
            return View();
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/plain"));
            HttpResponseMessage response1 = client.DeleteAsync("rest/project/" + id).Result;

            return RedirectToAction("Index");
        }

        public ActionResult Assign(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("rest/project/sk/"+id).Result;
            var skills = response.Content.ReadAsAsync<IEnumerable<skillsMv>>().Result;
            ViewBag.Myskills = new SelectList(skills, "idSkills", "name");
            return View();
        }

      
        [HttpPost]
        public ActionResult Assign(skillsMv sk, FormCollection collection,int id)
        {
          

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/plain"));
            HttpResponseMessage response1 =client.GetAsync("rest/project/" + id + "/" + sk.idSkills).Result;
            return RedirectToAction("Index");



        }
    }
}
