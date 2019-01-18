
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class MandateController : Controller
    {

        public MandateController()
        {
            ArchiveMandate();
            ViewBag.notif = 0;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("l4c_map-v2-web/rest/mandate?p=-69&r=-96").Result;
            IEnumerable<MandateVM> resultList = response.Content.ReadAsAsync<IEnumerable<MandateVM>>().Result;
            ViewBag.notif = resultList.Where(x=>x.archive == false ).Count();
        }


        public ActionResult EndingMandate()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/mandate").Result;
            IEnumerable<MandateVM> resultList = response.Content.ReadAsAsync<IEnumerable<MandateVM>>().Result;
            ViewBag.result = resultList;
            return View("Index");
        }

        public ActionResult ArchiveMandate()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.GetAsync("rest/mandate/archive?p=-69&r=-96");

            return View("Index");
        }
        // GET: Mandate
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("l4c_map-v2-web/rest/mandate").Result;
           
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<MandateVM>>().Result;
           
            return View();
        }
        // GET:  Mandate/HistoricalMandate
        public ActionResult HistoricalMandate()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/mandate/archive").Result;
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<MandateVM>>().Result;
            return View();
        }
        // GET: Mandate/Details
        public ActionResult Details(int p,int r)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/mandate").Result;

            IEnumerable<MandateVM> listMandate = response.Content.ReadAsAsync<IEnumerable<MandateVM>>().Result;
            MandateVM mandate = listMandate.Where(m => m.mandatepk.idProject == p && m.mandatepk.idRessource == r).ToList().First();
    
            return View(mandate);
        }

        // GET: Mandate/ProjectDetails/5
        public ActionResult ProjectDetails(int id)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/mandate/?p="+id).Result;

            ViewBag.result = response.Content.ReadAsAsync<IEnumerable<MandateVM>>().Result;


            return View("Index");
        }
        // GET: Mandate/RessourceDetails/5
        public ActionResult RessourceDetails(int id)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/mandate/?r=" + id).Result;

            ViewBag.result = response.Content.ReadAsAsync<IEnumerable<MandateVM>>().Result;


            return View("Index");
        }

        // GET: Mandate/Create
        public ActionResult Create()
        {
         
            ViewBag.idProject = 1;
            ViewBag.idRessource = 3;
                return View();
        }

        // POST: Mandate/Create
        [HttpPost]
        public ActionResult Create( MandateVM m)
        {
            try
            {
              
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web");
                System.Diagnostics.Debug.WriteLine("Mandate : " + m);
                m.duration = 0;
                m.mandateType = "Mandate";
                    client.PostAsJsonAsync<MandateVM>("rest/mandate", m).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
                    //HttpResponseMessage response = await Client.PostAsJsonAsync("rest/mandate/", request);

                    return RedirectToAction("Index");
              
                
            }
            catch
            {
                ViewBag.Errors = "erreur d'ajout";
                return View();
            }
        }

        // GET: Mandate/Edit/5
        public ActionResult Edit(int p , int r)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/mandate").Result;

            IEnumerable<MandateVM> listMandate = response.Content.ReadAsAsync<IEnumerable<MandateVM>>().Result;
            MandateVM mandate = listMandate.Where(m => m.mandatepk.idProject == p && m.mandatepk.idRessource == r).ToList().First();

            return View("Create",mandate);
        }

        // POST: Mandate/Edit/5
        [HttpPost]
        public ActionResult Edit(int p, int r, MandateVM m)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web");
                System.Diagnostics.Debug.WriteLine("Mandate : " + m);
                m.mandatepk.idProject = p;
                m.mandatepk.idRessource = r;
                client.PutAsJsonAsync<MandateVM>("rest/mandate", m).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
                //HttpResponseMessage response = await Client.PostAsJsonAsync("rest/mandate/", request);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mandate/search
        public ActionResult RessourcesList(int id)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/mandate/searsh/"+id).Result;

            ViewBag.result = response.Content.ReadAsAsync<IEnumerable<RessourceVm>>().Result;

            return View();
        }
    }
}
